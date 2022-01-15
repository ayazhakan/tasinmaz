import { Component, OnInit } from "@angular/core";
import { Form, NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { kullanici } from "../../models/kullanici";
import { KullaniciService } from "../../services/kullanici.service";
import { LoginService } from "../../services/login.service";
import { NavbarService } from "../../services/navbar.service";
@Component({
  selector: "app-kullaniciekle",
  templateUrl: "./kullaniciekle.component.html",
  styleUrls: ["./kullaniciekle.component.css"],
})
export class KullaniciekleComponent implements OnInit {
  yeniKullanici: kullanici = new kullanici();
  constructor(
    private router: Router,
    private service: KullaniciService,
    public nav: NavbarService,
    public login: LoginService
  ) {}

  ngOnInit() {
    this.nav.show();
    this.login.hide();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();

    this.service.formData.ad = "";
    this.service.formData.adres = "";
    this.service.formData.email = "";
    this.service.formData.kullaniciid = 0;
    this.service.formData.rol=null;
    this.service.formData.sifre= "";
    this.service.formData.silindimi=null;
    this.service.formData.soyad="";
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.service.addKullanici(form.value).subscribe(
      (res) => {
        this.resetForm();
        alert("Kullanıcı Eklendi");
        this.router.navigateByUrl("/kullanicilar");
      },
      (err) => {
        alert("Yanlis deger girdiniz");
      }
    );
  }
}
