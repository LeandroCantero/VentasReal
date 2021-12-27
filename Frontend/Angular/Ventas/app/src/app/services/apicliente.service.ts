import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';
import { Response } from '../models/response';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {

  url: string = 'https://localhost:44356/api/Cliente/';
  constructor(
    private _http: HttpClient
  ) { }

  getClientes(): Observable<Response>{
    return this._http.get<Response>(this.url+"Db");
  }

  add(cliente: Cliente):Observable<Response>{
    return this._http.post<Response>(this.url+"Add", cliente, httpOption);
  }

  edit(cliente: Cliente, id: number):Observable<Response>{
    return this._http.put<Response>(`${this.url+"Update"}/${id}`, cliente, httpOption);
  }

  delete(id: number):Observable<Response>{
    return this._http.delete<Response>(`${this.url+"Delete"}/${id}`);
  }

}
