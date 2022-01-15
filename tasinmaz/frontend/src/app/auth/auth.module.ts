import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { KullanicilarComponent } from './kullanicilar/kullanicilar.component';
import { TasinmazlarComponent } from './tasinmazlar/tasinmazlar.component';
import { LoglarComponent } from './loglar/loglar.component';
import { LoginComponent } from './login/login.component';
import { KullaniciekleComponent } from './kullanicilar/kullaniciekle/kullaniciekle.component';
import { KullaniciguncelleComponent } from './kullanicilar/kullaniciguncelle/kullaniciguncelle.component';
import { FormsModule} from '@angular/forms';
import { TasinmazekleComponent } from './tasinmazlar/tasinmazekle/tasinmazekle.component';
import { TasinmazGuncelleComponent } from './tasinmazlar/tasinmaz-guncelle/tasinmaz-guncelle.component';
import { NgxPaginationModule } from 'ngx-pagination'; 
import { Ng2SearchPipeModule } from 'ng2-search-filter';
@NgModule({
  declarations: [KullanicilarComponent,TasinmazlarComponent,LoglarComponent,LoginComponent, KullaniciekleComponent, KullaniciguncelleComponent, TasinmazekleComponent, TasinmazGuncelleComponent],
  imports: [
    CommonModule,Ng2SearchPipeModule ,
    AuthRoutingModule,FormsModule,NgxPaginationModule
  ],exports:[KullanicilarComponent,NgxPaginationModule,TasinmazlarComponent,LoglarComponent,LoginComponent,KullaniciekleComponent, KullaniciguncelleComponent]

})
export class AuthModule { }
