import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tasinmaz } from '../models/tasinmaz';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Pagination } from '../models/pagination';
import { PageRequest } from '../models/pagerequest';

@Injectable({
  providedIn: 'root'
})
export class TasinmazService {

  constructor(private http:HttpClient) { }


  formData: Tasinmaz=new Tasinmaz();
  getTasinmazAll():Observable<Tasinmaz[]>{

    return this.http.get<Tasinmaz[]>(environment.apiBaseURI+'/api/tasinmaz')
    
      }


  getTasinmaz(searchText:string,pagination:Pagination):Observable<PageRequest<Tasinmaz>>{
    return this.http.get<PageRequest<Tasinmaz>>(`${environment.apiBaseURI+'/api/tasinmaz/List'}?serchText=${searchText}&&page=${pagination.page}&&pageSize=${pagination.pageSize}`);
  }

  getTasinmazByID(id:number){
    return this.http.get(environment.apiBaseURI+"/api/tasinmaz/GetById/"+id)
  }

addTasinmaz(tasinmazz:Tasinmaz){
  return this.http.post(environment.apiBaseURI+"/api/tasinmaz",tasinmazz)
}
updateTasinmaz(tasinmazz:Tasinmaz){
return this.http.put(environment.apiBaseURI+"/api/tasinmaz",tasinmazz)
}
deleteTasinmaz(id:number){
  return this.http.delete(environment.apiBaseURI+"/api/tasinmaz/"+id)
}
getCity(){
  return this.http.get(environment.apiBaseURI+"/api/city")
}
getCounty(){
  return this.http.get(environment.apiBaseURI+"/api/county");
}
getNeighborhood(){
  return this.http.get(environment.apiBaseURI+"/api/neighborhood");
}

getCityById(id:number){
    return this.http.get(environment.apiBaseURI+"/api/city/GetById/"+id)

}
getCountyByCityId(cityid : number){
  return this.http.get(environment.apiBaseURI+"/api/county/"+cityid);
}
getNeighborhoodByCountyId(countyid?:number){
  return this.http.get(environment.apiBaseURI+"/api/neighborhood/"+countyid);
}

getTasinmazByText(searchText:string):Observable<Tasinmaz[]>{
  return this.http.get<Tasinmaz[]>(environment.apiBaseURI+"/api/tasinmaz/GetByText/"+searchText)
}

}
