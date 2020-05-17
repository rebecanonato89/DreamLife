import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";

const API = 'http://localhost/DreamLife.MyTrips/Trips/';
//const API = 'http://177.105.35.10/DreamLife.MyTrips/Trips/';

@Injectable({
  providedIn: 'root'
})
export class CadastroCidadeService {

  constructor(private http: HttpClient) { }

  InsertCidade(cidadeCadastrar) {
    console.log(cidadeCadastrar);
      return this.http
        .post(API + 'Cidade/', cidadeCadastrar);
  }

  UptadeCidade(cidadeAtualizar) {
    console.log(cidadeAtualizar);
      return this.http
        .put(API + 'Cidade/', cidadeAtualizar);
  }

  DeleteCidade(cidadeDeletarId) {
    console.log(cidadeDeletarId);
      return this.http
        .delete(API + 'Cidade/Delete/' + cidadeDeletarId);
  }
}
