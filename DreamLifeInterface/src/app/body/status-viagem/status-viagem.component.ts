import { Component, OnInit, Input } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { Cidade } from '../cidade.model';
import { hotelCidadeIdService } from '../hotel-CidadeId.service';
import { FormControl } from '@angular/forms';
//import { DataService } from '../data.service';

@Component({
  selector: 'app-status-viagem',
  templateUrl: './status-viagem.component.html',
  styleUrls: ['./status-viagem.component.css']
})
export class StatusViagemComponent implements OnInit {

  @Input() template: boolean;

  public placeholderIcon = require('../../../imagens/placeholder.svg');
  public calendarIcon = require('../../../imagens/calendar-page-empty.svg');
  public manUserIcon = require('../../../imagens/man-user.svg');
  public crownIcon = require('../../../imagens/crown.svg');
  public creditCardIcon = require('../../../imagens/credit-card.svg');

  cidades: Cidade[] = [];
  cidadeId: number;

  date = new FormControl(new Date());

  constructor(private cidadeService: CidadeService, private hotelCidadeIdService: hotelCidadeIdService) { }
  //private dataService: DataService

  ngOnInit(): void {

    this.cidadeService
      .listCidade()
      .subscribe(cidade => { this.cidades = cidade });
    //.subscribe(cidade => { this.cidades = cidade; console.log(this.cidades) });

    //this.dataService.getCidades().subscribe(data => this.cidades = data);
  }

  onAddCidade() {
    this.cidadeId = +this.cidadeId;
    //console.log("estou no StatusViagemComponent - " + this.cidadeId);
    this.hotelCidadeIdService.addCidade(this.cidadeId);
  }

}
