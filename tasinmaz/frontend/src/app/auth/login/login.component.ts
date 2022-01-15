import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { forEach } from "@angular/router/src/utils/collection";
import { catchError } from "rxjs/operators";
import { kullanici } from "../models/kullanici";
import { Login } from "../models/login";
import { LoginService } from "../services/login.service";
import { NavbarService } from "../services/navbar.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  error: string;
  giris = new Login();
  kullanici = new kullanici();

  constructor(
    private http: HttpClient,
    private router: Router,
    private service: LoginService,
    public nav: NavbarService
  ) {}
  kullaniciBilgileri:kullanici =new kullanici();
  ngOnInit() {
    this.nav.hide();
    this.nav.doSomethingElseUseful();
    
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    console.log(form.valid);
    
  }
  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.kullaniciBilgileri.email="";
    this.kullaniciBilgileri.sifre="";
  

  }
  onLogin() {
    this.service.login(this.kullaniciBilgileri).subscribe(
      (res) => {
        console.log(res);
        console.log(this.kullaniciBilgileri);
        (this.kullanici = res as {}),
          this.rolKontrol(this.kullanici.rol),
          this.router.navigateByUrl("/tasinmazlar");
          this.resetForm();
      },
      (err) => {
        console.log(this.kullaniciBilgileri);
        this.error = err.error;
        console.log(this.error), alert("wrong details");
      }
    );
  }

  rolKontrol(rol: boolean) {
    if (rol == true) this.nav.userOrAdmin = true;
    else if (rol == false) this.nav.userOrAdmin = false;
    else this.nav.hide();
  }
}
