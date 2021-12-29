import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from "../models/response";


const httpOption = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

@Injectable({
    providedIn: 'root'
})
export class ApiauthService {
    url: string = 'https://localhost:44356/api/User/login';

    constructor(private _http: HttpClient){

    }

    login(email: string, password: string): Observable<Response>{
        return this._http.post<Response>(this.url, {email, password}, httpOption);
    }
}