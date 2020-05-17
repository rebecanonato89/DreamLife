import { Component, OnInit } from '@angular/core';
import { CidadeService } from '../cidade.service';
import { CadastroCidadeService } from '../cadastrarcidade/cadastro-cidade.service';
import { Cidade } from '../cidade.model';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-cadastrarcidade',
  templateUrl: './cadastrarcidade.component.html',
  styleUrls: ['./cadastrarcidade.component.css']
})
export class CadastrarcidadeComponent implements OnInit {

  cidades: Cidade[] = [];

  cidadeCadastrar: Cidade = new Cidade();
  cidadeDeletar: Cidade = new Cidade();
  cidadeDeletarId: number;
  cidadeAtualizar: Cidade = new Cidade();
  onEdit: boolean = true;

  constructor(private cidadeService: CidadeService, private cadastroCidadeService: CadastroCidadeService) { }

  ngOnInit() {
    this.cidadeService
      .listCidade()
      .subscribe(cidade => { this.cidades = cidade });
  }

  inserir(f: NgForm) {
    this.cadastroCidadeService
      .InsertCidade(this.cidadeCadastrar)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
    f.resetForm();
  }

  update(i: number) {
    this.cidadeAtualizar = this.cidades[i];
    this.onEdit = false;
  }

  Update_serve() {
    this.cadastroCidadeService
      .UptadeCidade(this.cidadeAtualizar)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
    this.onEdit = true;
  }

  delete(i: number) {
    this.cidadeDeletar = this.cidades[i];
    this.cidadeDeletarId = this.cidadeDeletar.Id;
    this.cadastroCidadeService
      .DeleteCidade(this.cidadeDeletarId)
      .subscribe(res => {
        console.log(res);
        this.ngOnInit();
      });
  }
  volta() {
    this.onEdit = true;
  }
}
