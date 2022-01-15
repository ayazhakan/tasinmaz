import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { count } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Loglar } from "../models/loglar";
import { PageRequest } from "../models/pagerequest";
import { Pagination } from "../models/pagination";
import { ExcelService } from "../services/excel.service";
import { LogService } from "../services/log.service";
import { LoginService } from "../services/login.service";
import { NavbarService } from "../services/navbar.service";


@Component({
  selector: "app-loglar",
  templateUrl: "./loglar.component.html",
  styleUrls: ["./loglar.component.css"],
})
export class LoglarComponent implements OnInit {
  p: number = 1;
  constructor(
    private http: HttpClient,
    private router: Router,
    public service: ExcelService,
    public logService: LogService,
    public nav: NavbarService,
    public login: LoginService
  ) {}
  public searchText: string = "";
  public loglar: Loglar[];
  public pagination: Pagination = new Pagination(1, 0, 5, [5, 10, 15, 20]);
  adet:Number;
  ngOnInit() {
    this.getAllLog();
    this.nav.show();
    this.nav.doSomethingElseUseful();
    this.login.hide();
    this.login.hide();
  }
  getAllLog() {
    this.logService.getLogAll().subscribe(
      (x) => {
        this.loglar = x;
        this.pagination.count=x.length;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getLog() {
    this.logService.getLog(this.searchText, this.pagination).subscribe(
      (x) => {
        this.loglar = x.items as Loglar[];
        this.pagination.count = x.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onPageChange(event) {
    this.pagination.page = event;


   
  this.getLog();



    
  }

  onPageSizeChange(event) {
    this.pagination.pageSize = event.target.value;
    this.pagination.page = 1;
    this.getLog();
  }

  logAra() {
   this.pagination.page = 1;
    if (this.searchText != "" && this.searchText != null) {
      this.logService.getLogByText(this.searchText).subscribe((res) => {
        this.loglar = res as Loglar[]; 
       
  
   this.pagination.count=res.length;
   this.pagination.pageSize=5;
      }),
        (error) => {
          console.log(error);
        };
    } else {
      this.getLog();
    }
  }

  yazdirLog(log: Loglar) {
    let reportData = {
      title: "LOGLAR",
      headers: ["ID", "DURUM", "İŞLEM TİPİ", "TARİH/SAAT", "IP", "AÇIKLAMA"],
      data: [
        log.id,
        log.durum,
        log.islemtipi,
        log.tarihsaat,
        log.ip,
        log.acikklama,
      ],
    };
    this.service.exportExcel(reportData);
    console.log(log);
  }
}
