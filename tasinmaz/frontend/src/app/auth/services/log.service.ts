import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PageRequest } from '../models/pagerequest';
import { Loglar } from '../models/loglar';
import { Pagination } from '../models/pagination';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor(private http:HttpClient) { }


  getLog(searchText:string,pagination:Pagination):Observable<PageRequest<Loglar>>{
    return this.http.get<PageRequest<Loglar>>(`${environment.apiBaseURI+'/api/log/List'}?serchText=${searchText}&&page=${pagination.page}&&pageSize=${pagination.pageSize}`);
  }


  getLogByText(searchText:string):Observable<Loglar[]>{
return this.http.get<Loglar[]>(environment.apiBaseURI+'/api/log/'+searchText);

  }

  getLogAll():Observable<Loglar[]>{

return this.http.get<Loglar[]>(environment.apiBaseURI+'/api/log')

  }
}
