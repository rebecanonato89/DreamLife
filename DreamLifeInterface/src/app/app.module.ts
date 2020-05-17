import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { BodyComponent } from './body/body.component';
import { HotelComponent } from './body/hotel/hotel.component';
import { StatusViagemComponent } from './body/status-viagem/status-viagem.component';
import { CadastrarhotelComponent } from './body/cadastrarhotel/cadastrarhotel.component';
import { CadastrarcidadeComponent } from './body/cadastrarcidade/cadastrarcidade.component';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { AppRoutingModule } from './/app-routing.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import {StarRatingModule} from 'angular-star-rating';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BodyComponent,
    HotelComponent,
    StatusViagemComponent,
    CadastrarhotelComponent,
    CadastrarcidadeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MaterialModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    StarRatingModule.forRoot(),
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
