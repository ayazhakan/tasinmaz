import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map } from "rxjs/operators";
import { Login } from "../models/login";
@Injectable({
  providedIn: "root",
})
export class LoginService {
  constructor(private http: HttpClient) {
    this.visible = true;
  }
  visible: boolean;
  login(model: Login) {
    return this.http.post<Login>(environment.apiBaseURI + "/api/login", model);
  }

  hide() {
    this.visible = false;
  }

  show() {
    this.visible = true;
  }

  toggle() {
    this.visible = !this.visible;
  }

  doSomethingElseUseful() {}
}
