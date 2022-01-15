import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { City } from "../../models/city";
import { County } from "../../models/county";
import { Neighborhood } from "../../models/neighborhood";
import { Tasinmaz } from "../../models/tasinmaz";
import { LoginService } from "../../services/login.service";
import { NavbarService } from "../../services/navbar.service";
import { TasinmazService } from "../../services/tasinmaz.service";

@Component({
  selector: "app-tasinmaz-guncelle",
  templateUrl: "./tasinmaz-guncelle.component.html",
  styleUrls: ["./tasinmaz-guncelle.component.css"],
})
export class TasinmazGuncelleComponent implements OnInit {
  gelenMahalleId: number;
  gelenTasinmazId: number;
  guncellenecekTasinmaz: Tasinmaz = new Tasinmaz();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public service: TasinmazService,
    public nav: NavbarService,
    public login:LoginService
  ) {}

  county: County[];
  neighborhood: Neighborhood[];
  tasinmaz: Tasinmaz[];
  city: City[];

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.gelenTasinmazId = +params["tasinmazid"];
    });

    this.loadData();
    this.nav.show();
    this.login.hide();
  }
  loadData() {
    this.service.getTasinmazByID(this.gelenTasinmazId).subscribe((data) => {
      (this.guncellenecekTasinmaz = data as {}), console.log(data);

      this.service.getCity().subscribe((x) => {
        this.city = x as [];
      });
      this.service
        .getCountyByCityId(this.guncellenecekTasinmaz.cityid)
        .subscribe((x) => {
          this.county = x as [];
        });
      this.service
        .getNeighborhoodByCountyId(this.guncellenecekTasinmaz.countyid)
        .subscribe((x) => {
          this.neighborhood = x as [];
        });
    });
  }
  secilenCity(id: number) {
    this.service.getCountyByCityId(id).subscribe((x) => {
      this.county = x as [];
      this.service.getNeighborhoodByCountyId().subscribe((x) => {
        this.neighborhood = x as [];
      });
    });
  }
  secilenCounty(id: number) {
    this.service.getNeighborhoodByCountyId(id).subscribe((x) => {
      this.neighborhood = x as [];
    });
  }
  secilenMahalle(gelenMahalleId?: string) {
    this.gelenMahalleId = Number(gelenMahalleId);
  }

  onSubmit(form: NgForm) {
    console.log(this.guncellenecekTasinmaz);

    this.service.updateTasinmaz(this.guncellenecekTasinmaz).subscribe(
      (res) => {
        alert("Taşınmaz Güncellendi");
        this.router.navigateByUrl("/tasinmazlar");
      },
      (err) => {
        alert("Yanlis deger girdiniz");
      }
    );
  }
}
