import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { kullanici } from "../../models/kullanici";
import { KullaniciService } from "../../services/kullanici.service";
import { LoginService } from "../../services/login.service";
import { NavbarService } from "../../services/navbar.service";

@Component({
  selector: "app-kullaniciguncelle",
  templateUrl: "./kullaniciguncelle.component.html",
  styleUrls: ["./kullaniciguncelle.component.css"],
})
export class KullaniciguncelleComponent implements OnInit {
  constructor(
    public login: LoginService,
    private router: Router,
    private service: KullaniciService,
    private route: ActivatedRoute,
    public nav: NavbarService
  ) {}
  kullanici = [];
  id: number;
  guncellenecekKullanici = new kullanici();

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params["kullaniciid"];
    });
    this.nav.show();

    this.login.hide();

    this.loadData();
    console.log(this.id);
  }

  loadData() {
    this.service
      .getKullaniciByID(this.id)
      .subscribe((data) => (this.guncellenecekKullanici = data as {}));
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.service.updateKullanici(form.value).subscribe(
      (res) => {
        alert("Kullanıcı Güncellendi");
        this.router.navigateByUrl("/kullanicilar");
      },
      (err) => {
        alert("Yanlis deger girdiniz");
      }
    );
  }
}
