import { Component, OnInit } from '@angular/core';
import { Hotel } from '../hotel.model';
import { hotelCidadeIdService } from '../hotel-CidadeId.service';
import {NgbRatingConfig} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent implements OnInit {

  onEdit: boolean = true;
  idHotel: number;
  nomeHotel: string;
  descricaoHotel: string;
  imagemHotel: string;
  classificacaoHotel: number;
  hotels: Hotel[] = [];
  enable: number;


  constructor(private hotelCidadeIdService: hotelCidadeIdService, config: NgbRatingConfig) {
    config.max = 5;
    config.readonly = true;
  }

  ngOnInit(): void {
    hotelCidadeIdService.carregouNovaCidade.subscribe(
      id => //console.log(id)
        this.hotelCidadeIdService
          .listTrips(id)
          .subscribe(hotel => { this.hotels = hotel; this.enable = hotel.length; console.log(hotel); })
    );
  }

  descricao(hotel: Hotel) {
    //console.log("chamei o click " + hotel.Id);
    this.idHotel = hotel.Id;
    this.nomeHotel = hotel.NomeHotel;
    this.descricaoHotel = hotel.Descricao;
    this.imagemHotel = hotel.Imagem;
    this.classificacaoHotel = hotel.Classificacao;
    this.onEdit = false;
  }

  volta() {
    this.onEdit = true;
  }

}
