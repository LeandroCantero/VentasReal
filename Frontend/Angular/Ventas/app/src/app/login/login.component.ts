import { Component, OnInit } from "@angular/core";
import { ApiauthService } from "../services/apiauth.service";

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

    public email!: string;
    public password!: string;

    constructor (public apiauth: ApiauthService){

    } 

    ngOnInit(){
        
    }

    login(){
        this.apiauth.login(this.email, this.password).subscribe(response =>{
            console.log(response);
        });
    }
}