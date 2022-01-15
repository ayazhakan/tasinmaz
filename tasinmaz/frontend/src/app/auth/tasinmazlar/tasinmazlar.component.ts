import { Component, OnInit } from "@angular/core";
import { FormArray, FormBuilder } from "@angular/forms";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Router } from "@angular/router";
import { TasinmazService } from "../services/tasinmaz.service";
import { Tasinmaz } from "../models/tasinmaz";
import { ExcelService } from "../services/excel.service";
import { Pagination } from "../models/pagination";
import { NavbarService } from "../services/navbar.service";
import { LoginService } from "../services/login.service";
@Component({
  selector: "app-tasinmazlar",
  templateUrl: "./tasinmazlar.component.html",
  styleUrls: ["./tasinmazlar.component.css"],
})
export class TasinmazlarComponent implements OnInit {
  public searchText: string = "";
  public tasinmaz: Tasinmaz[];
  public pagination: Pagination = new Pagination(1, 0, 5, [10, 20, 30, 40]);
  tasinmazList = [];

  constructor(
    private http: HttpClient,
    private router: Router,
    private service: TasinmazService,
    private servicee: ExcelService,
    public nav: NavbarService,
    public login:LoginService
  ) {}

  ngOnInit() {
    this.getAllTasinmaz();
    this.nav.show();
    this.login.hide();
  }

  getAllTasinmaz() {
    this.service.getTasinmazAll().subscribe(
      (x) => {
        this.tasinmaz = x as Tasinmaz[];
        this.pagination.count = x.length;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getTasinmaz() {
    this.service.getTasinmaz(this.searchText, this.pagination).subscribe(
      (x) => {
        this.tasinmaz = x.items as Tasinmaz[];
        this.pagination.count = x.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onPageChange(event) {
    this.pagination.page = event;
    this.getTasinmaz();
  }
  tasinmazAra() {
    if (this.searchText != "" && this.searchText != null) {
      this.service.getTasinmazByText(this.searchText).subscribe((res) => {
        this.tasinmaz = res as Tasinmaz[];
        this.pagination.count = res.length;
        this.pagination.pageSize = 5;
      });
    } else {
      this.getAllTasinmaz();
    }
  }
  onPageSizeChange(event) {
    this.pagination.pageSize = event.target.value;
    this.pagination.page = 1;
    this.getTasinmaz();
  }

  deleteTasinmaz(id: number) {
    if (confirm("Silmek istediğinize emin misiniz ?")) {
      this.http
        .delete(environment.apiBaseURI + "/api/tasinmaz/" + id)
        .subscribe((res) => {
          this.getAllTasinmaz();
        });
    }
  }
  yazdirTasinmaz(tasinmaz: Tasinmaz) {
    let reportData = {
      title: "TASINMAZLAR",
      headers: ["İL", "İLÇE", "MAHALLE", "ADA", "PARSEL", "NİTELİK", "ADRES"],
      data: [
        tasinmaz.cityname,
        tasinmaz.countyname,
        tasinmaz.neighborhoodname,
        tasinmaz.ada,
        tasinmaz.parsel,
        tasinmaz.nitelik,
        tasinmaz.adres,
      ],
    };
    this.servicee.exportExcel(reportData);
  }
}
