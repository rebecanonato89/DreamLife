import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { Cidade } from '../cidade.model';
import { Hotel } from '../hotel.model';
import { CadastroHotelService } from './cadastro-hotel.service';
import { NgForm } from '@angular/forms';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-cadastrarhotel',
  templateUrl: './cadastrarhotel.component.html',
  styleUrls: ['./cadastrarhotel.component.css']
})
export class CadastrarhotelComponent implements OnInit {

  cidades: Cidade[] = [];
  cidadeId: number;
  onEditCidade: boolean;
  formConcluido: boolean = false;
  onEdit: boolean;

  hoteis: Hotel[] = [];
  cadastrarHotel: Hotel = new Hotel();
  currentRate = 1;

  hotelDeletar: Hotel = new Hotel();
  hotelAtualizar: Hotel = new Hotel();
  hotelDeletarId: number;


  public placeholderIcon = require('../../../imagens/placeholder.svg');

  constructor(private cidadeService: CidadeService, private cadastroHotelService: CadastroHotelService, config: NgbRatingConfig) {
    config.max = 5;
    config.readonly = true;
  }

  ngOnInit(): void {

    this.onEditCidade = true;
    this.onEdit = true;

    this.cidadeService
      .listCidade()
      .subscribe(cidade => { this.cidades = cidade });

    this.cadastroHotelService
      .listHotel()
      .subscribe(hotel => { this.hoteis = hotel, console.log(hotel)});
  }

  onAddCidade() {
    this.cidadeId = +this.cidadeId;
    console.log(this.cidadeId);
    this.onEditCidade = false;
  }

  inserir(f: NgForm) {
    this.cadastrarHotel.Classificacao = this.currentRate;
    this.cadastrarHotel.CidadeId = this.cidadeId;
    this.formConcluido = true;
    this.cadastroHotelService
      .InsertHotel(this.cadastrarHotel)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
  }

  cancelar(f: NgForm) {
    f.resetForm();
    this.onEditCidade = true;
    this.onEdit = true;
  }

  cancelarUpdate(){
    this.onEditCidade = true;
    this.onEdit = true;
  }

  update(i: number) {
    console.log(this.hoteis[i]);
    this.hotelAtualizar = this.hoteis[i];
    this.onEdit = false;
  }

  Update_serve() {
    console.log(this.hotelAtualizar);
    this.formConcluido = true;
    this.cadastroHotelService
      .UptadeHotel(this.hotelAtualizar)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
  }

  delete(i: number) {
    console.log("Delete" + this.hoteis[i]);
    this.hotelDeletar = this.hoteis[i];
    this.hotelDeletarId = this.hotelDeletar.Id;
    this.cadastroHotelService
      .DeleteHotel(this.hotelDeletarId)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
  }

}
