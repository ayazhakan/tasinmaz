import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KullaniciekleComponent } from './kullanicilar/kullaniciekle/kullaniciekle.component';
import { KullaniciguncelleComponent } from './kullanicilar/kullaniciguncelle/kullaniciguncelle.component';
import { KullanicilarComponent } from './kullanicilar/kullanicilar.component';
import { LoginComponent } from './login/login.component';
import { LoglarComponent } from './loglar/loglar.component';
import { TasinmazGuncelleComponent } from './tasinmazlar/tasinmaz-guncelle/tasinmaz-guncelle.component';
import { TasinmazekleComponent } from './tasinmazlar/tasinmazekle/tasinmazekle.component';
import { TasinmazlarComponent } from './tasinmazlar/tasinmazlar.component';

const routes: Routes = [{path: 'tasinmazlar', component:TasinmazlarComponent},
{path: 'kullanicilar', component:KullanicilarComponent},
{path: 'login', component:LoginComponent},
{path: 'loglar', component:LoglarComponent},
{path:'kullaniciekle',component:KullaniciekleComponent},{path:'kullaniciguncelle/:kullaniciid' ,component:KullaniciguncelleComponent},
{path:'tasinmazekle',component:TasinmazekleComponent},{path:'tasinmaz-guncelle/:tasinmazid',component:TasinmazGuncelleComponent}];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class AuthRoutingModule { }
