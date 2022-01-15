import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { kullanici } from "../models/kullanici";
import { Pagination } from "../models/pagination";
import { ExcelService } from "../services/excel.service";
import { KullaniciService } from "../services/kullanici.service";
import { LoginService } from "../services/login.service";
import { NavbarService } from "../services/navbar.service";

@Component({
  selector: "app-kullanicilar",
  templateUrl: "./kullanicilar.component.html",
  styleUrls: ["./kullanicilar.component.css"],
})
export class KullanicilarComponent implements OnInit {
  public searchText: string = "";
  public kullanici: kullanici[];
  public pagination: Pagination = new Pagination(1, 0, 5, [10, 20, 30, 40]);
  p: number = 1;
  formData: kullanici;
  user = [];
  kullaniciList = [];
  excelData = [];
  constructor(
    private http: HttpClient,
    private router: Router,
    public service: ExcelService,
    private kullaniciService: KullaniciService,
    public nav: NavbarService,
    public login: LoginService
  ) {}

  ngOnInit() {
    this.getAllKullanici();
    this.nav.show();
    this.nav.doSomethingElseUseful();
    this.login.hide();
    this.login.hide();
  }

  yazdirKullanici(kullanici: kullanici) {
    if (kullanici.rol == true) {
      let reportData = {
        title: "kullanıcı",
        headers: ["ID", "AD", "SOYAD", "EMAİL", "ŞİFRE", "ROL", "ADRES"],
        data: [
          kullanici.kullaniciid,
          kullanici.ad,
          kullanici.soyad,
          kullanici.email,
          kullanici.sifre,
          "ADMIN",
          kullanici.adres,
        ],
      };
      this.service.exportExcel(reportData);
      console.log(kullanici);
    } else if (kullanici.rol == false) {
      let reportData = {
        title: "kullanıcı",
        headers: ["ID", "AD", "SOYAD", "EMAİL", "ŞİFRE", "ROL", "ADRES"],
        data: [
          kullanici.kullaniciid,
          kullanici.ad,
          kullanici.soyad,
          kullanici.email,
          kullanici.sifre,
          "KULLANICI",
          kullanici.adres,
        ],
      };
      this.service.exportExcel(reportData);
      console.log(kullanici);
    }
  }

  getAllKullanici() {
    this.kullaniciService.getKullaniciAll().subscribe(
      (x) => {
        this.kullanici = x as kullanici[];
        this.pagination.count = x.length;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getKullanici() {
    this.kullaniciService
      .getKullanici(this.searchText, this.pagination)
      .subscribe(
        (x) => {
          this.kullanici = x.items as kullanici[];
          this.pagination.count = x.count;
        },
        (error) => {
          console.log(error);
        }
      );
  }
  onPageChange(event) {
    this.pagination.page = event;
    this.getKullanici();
  }

  onPageSizeChange(event) {
    this.pagination.pageSize = event.target.value;
    this.pagination.page = 1;
    this.getKullanici();
  }
  kullaniciAra() {
    this.pagination.page = 1;
    if (this.searchText != "" && this.searchText != null) {
      this.kullaniciService
        .getKullaniciByText(this.searchText)
        .subscribe((res) => {
          this.kullanici = res as kullanici[];
          this.pagination.count = res.length;
          this.pagination.pageSize = 5;
        });
    } else {
      this.getAllKullanici();
    }
  }
  deleteKullanici(id: number) {
    if (confirm("Silmek istediğinize emin misiniz ?")) {
      this.http
        .delete(environment.apiBaseURI + "/api/kullanici/" + id)
        .subscribe((res) => {
          this.getAllKullanici();
        });
    }
  }
}
