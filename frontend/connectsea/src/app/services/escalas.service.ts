import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Escala } from '../models/escala.model';

@Injectable({
  providedIn: 'root'
})
export class EscalasService {

    private readonly baseUrl = 'http://localhost:8080/escalas';

    constructor(private http: HttpClient) {}

    listar(): Observable<Escala[]> {
      return this.http.get<Escala[]>(this.baseUrl);
    }
}
