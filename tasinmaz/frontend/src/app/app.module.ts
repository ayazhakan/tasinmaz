import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgxPaginationModule} from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { TasinmazlarComponent } from './auth/tasinmazlar/tasinmazlar.component';
import { KullanicilarComponent } from './auth/kullanicilar/kullanicilar.component';
import { LoglarComponent } from './auth/loglar/loglar.component';
import {ReactiveFormsModule} from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { AuthModule } from './auth/auth.module';
import { KullaniciService } from './auth/services/kullanici.service';
import { Ng2SearchPipeModule } from 'ng2-search-filter';


const routes : Routes = [{path: 'tasinmazlar', component:TasinmazlarComponent},
{path: 'kullanicilar', component:KullanicilarComponent},
{path: 'login', component:LoginComponent},
{path: 'loglar', component:LoglarComponent}];


@NgModule({
  declarations: [	
    AppComponent, 
     
   ],
  imports: [AuthModule,
    BrowserModule,
    AppRoutingModule,ReactiveFormsModule,HttpClientModule,SharedModule,Ng2SearchPipeModule,RouterModule,NgxPaginationModule
  ],
  providers: [KullaniciService],
  bootstrap: [AppComponent]
})
export class AppModule { }
