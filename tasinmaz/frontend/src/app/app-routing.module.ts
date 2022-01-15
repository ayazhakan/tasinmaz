import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { TasinmazlarComponent } from './auth/tasinmazlar/tasinmazlar.component';
import { KullanicilarComponent } from './auth/kullanicilar/kullanicilar.component';
import { LoglarComponent } from './auth/loglar/loglar.component';

const routes: Routes = [];

@NgModule({
 
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
