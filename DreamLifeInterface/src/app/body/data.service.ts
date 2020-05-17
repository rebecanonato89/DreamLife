import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cidade } from './cidade.model';
import { Hotel } from './hotel.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  Api = 'http://177.105.34.165/MyTrips/MyTrips/';

  constructor(private _http: HttpClient) { }

  getCidades(){
    return this._http.get<Cidade[]>(this.Api + 'Cidade');
  }

  getHoteis(){
    return this._http.get<Hotel[]>(this.Api + 'Hotel');
  }
  getHoteisPorIdCidade(id){
    return this._http.get<Hotel[]>(this.Api + 'Hotel?idCidade=' + id);
  }
}
