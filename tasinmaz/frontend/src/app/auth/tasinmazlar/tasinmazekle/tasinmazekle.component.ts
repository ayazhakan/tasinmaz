import { Component, OnInit } from "@angular/core";
import { TasinmazService } from "../../services/tasinmaz.service";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { City } from "../../models/city";
import { County } from "../../models/county";
import { Neighborhood } from "../../models/neighborhood";
import { Tasinmaz } from "../../models/tasinmaz";
import { NgForm } from "@angular/forms";
import { Variable } from "@angular/compiler/src/render3/r3_ast";
import { NavbarService } from "../../services/navbar.service";
import { LoginService } from "../../services/login.service";

@Component({
  selector: "app-tasinmazekle",
  templateUrl: "./tasinmazekle.component.html",
  styleUrls: ["./tasinmazekle.component.css"],
})
export class TasinmazekleComponent implements OnInit {
  yeniTasinmaz: Tasinmaz = new Tasinmaz();
  county: County[];
  neighborhood: Neighborhood[];
  tasinmaz: Tasinmaz[];
  city: City[];
  formData: [];

  selectedCity: number;
  selectedCounty: number;
  selectedNeighborhood: number;
  gelenid: number;

  constructor(
    private http: HttpClient,
    private router: Router,
    private service: TasinmazService,
    public nav: NavbarService,
    public login:LoginService
  ) {}

  ngOnInit() {
    this.service.getCity().subscribe((x) => {
      this.city = x as [];
    });
    this.resetForm();
    this.nav.show();

    this.login.hide();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();

    this.yeniTasinmaz.ada;
    this.yeniTasinmaz.adres = "";
    this.yeniTasinmaz.neighborhoodid = 0;
    this.yeniTasinmaz.nitelik = "";
    this.yeniTasinmaz.parsel;
    this.yeniTasinmaz.tasinmazid = 0;
  }

  secilenCity(id: number) {
    this.service.getCountyByCityId(id).subscribe((x) => {
      this.county = x as [];
      this.service.getNeighborhoodByCountyId(null).subscribe((x) => {
        this.neighborhood = x as [];
      });
    });
  }
  secilenCounty(id: number) {
    this.service.getNeighborhoodByCountyId(id).subscribe((x) => {
      this.neighborhood = x as [];
    });
  }

  secilenMahalle(gelenMahalleId: string) {
    this.gelenid = Number(gelenMahalleId);
  }

  onSubmit(form: NgForm) {
    console.log(this.yeniTasinmaz);

    this.yeniTasinmaz.neighborhoodid = this.gelenid;
    this.service.addTasinmaz(this.yeniTasinmaz).subscribe(
      (res) => {
        this.resetForm(form);
        alert("Taşınmaz Eklendi");
        this.router.navigateByUrl("/tasinmazlar");
      },
      (err) => {
        alert("Yanlis deger girdiniz");
      }
    );
  }
}
