import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';



import { Hotel } from './hotel.model';

const API = 'http://localhost/DreamLife.MyTrips/Trips/';
//const API = 'http://177.105.35.10/DreamLife.MyTrips/Trips/';

@Injectable({ providedIn: 'root' })
export class hotelCidadeIdService {

    static carregouNovaCidade = new EventEmitter<number>();

    constructor(private http: HttpClient) { }

    addCidade(id: number) {
        //console.log("Estou no tripsServices - " + id);
        hotelCidadeIdService.carregouNovaCidade.emit(id);
    }

    listTrips(id) {
        let params = new HttpParams().set('CidadeId', id);
        return this.http
            .get<Hotel[]>(API + 'Hotel', {params: params});
    }


}
