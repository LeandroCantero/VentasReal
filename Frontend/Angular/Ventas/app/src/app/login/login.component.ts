import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ApiauthService } from "../services/apiauth.service";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

    public loginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
    });

    constructor (public apiauth: ApiauthService, private router: Router, private formBuilder: FormBuilder){

    } 

    ngOnInit(){
        
    }

    login(){
        this.apiauth.login(this.loginForm.value).subscribe(response =>{
            if (response.exito === 1) {
                //this.router.navigate(['/']);
            }
        });
    }
}