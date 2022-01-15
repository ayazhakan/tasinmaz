import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/auth/services/login.service';
import { NavbarService } from 'src/app/auth/services/navbar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})  
export class HeaderComponent implements OnInit {

  constructor(public service:NavbarService,public login:LoginService) { }

  ngOnInit() {
  }

onClick(){
  this.service.hide();
  this.login.toggle();
}

}
