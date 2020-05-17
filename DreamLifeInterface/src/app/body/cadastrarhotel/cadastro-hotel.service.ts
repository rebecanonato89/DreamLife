import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Hotel } from '../hotel.model';

const API = 'http://localhost/DreamLife.MyTrips/Trips/';
//const API = 'http://177.105.35.10/DreamLife.MyTrips/Trips/';

@Injectable({
  providedIn: 'root'
})
export class CadastroHotelService {

  constructor(private http: HttpClient) { }

  listHotel() {
    return this.http
        .get<Hotel[]>(API + 'Hotel');
}

  InsertHotel(hotelCadastrar) {
    console.log(hotelCadastrar);
      return this.http
        .post(API + 'hotel/', hotelCadastrar);
  }

  UptadeHotel(HotelAtualizar) {
    console.log(HotelAtualizar);
      return this.http
        .put(API + 'hotel/', HotelAtualizar);
  }

  DeleteHotel(HotelDeletarId) {
    console.log(HotelDeletarId);
      return this.http
        .delete(API + 'hotel/Delete/' + HotelDeletarId);
  }
}
