import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { kullanici } from '../models/kullanici';
import { Observable } from 'rxjs';

import { Subject } from 'rxjs';
import { PageRequest } from '../models/pagerequest';
import { Pagination } from '../models/pagination';
@Injectable({
  providedIn: 'root'
})
export class KullaniciService {

  
formData: kullanici=new kullanici();

  constructor(private http:HttpClient) { }

addKullanici(kullanicii:kullanici){

  return this.http.post(environment.apiBaseURI+'/api/kullanici',kullanicii);
  
}
getKullanici(searchText:string,pagination:Pagination):Observable<PageRequest<kullanici>>{
  return this.http.get<PageRequest<kullanici>>(`${environment.apiBaseURI+'/api/kullanici/List'}?serchText=${searchText}&&page=${pagination.page}&&pageSize=${pagination.pageSize}`);
}
getKullaniciByID(id:number){
return this.http.get(environment.apiBaseURI+'/api/kullanici/GetById/'+id)
}

updateKullanici(kullanicii:kullanici){

 return this.http.put(environment.apiBaseURI+'/api/kullanici',kullanicii) 
}
getKullaniciByText(searchText:string):Observable<kullanici[]>{
  return this.http.get<kullanici[]>(environment.apiBaseURI+'/api/kullanici/GetByText/'+searchText)
  }

  getKullaniciAll():Observable<kullanici[]>{
    return this.http.get<kullanici[]>(environment.apiBaseURI+'/api/kullanici')
    }


}
