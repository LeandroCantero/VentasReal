import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ApiauthService } from "../services/apiauth.service";

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

    public email!: string;
    public password!: string;

    constructor (public apiauth: ApiauthService, private router: Router){

    } 

    ngOnInit(){
        
    }

    login(){
        this.apiauth.login(this.email, this.password).subscribe(response =>{
            if (response.exito === 1) {
                this.router.navigate(['/']);
            }
        });
    }
}