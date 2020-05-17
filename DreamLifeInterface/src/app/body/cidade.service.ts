import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cidade } from './cidade.model';

const API = 'http://localhost/DreamLife.MyTrips/Trips/';
//const API = 'http://177.105.35.10/DreamLife.MyTrips/Trips/';


@Injectable({ providedIn: 'root' })
export class CidadeService {

    constructor(private http: HttpClient) {}

    listCidade() {
        return this.http
            .get<Cidade[]>(API + 'Cidade');
    }
}
