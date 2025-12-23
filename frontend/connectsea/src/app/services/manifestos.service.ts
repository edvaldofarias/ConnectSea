import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Manifesto } from '../models/manifesto.model';

@Injectable({
  providedIn: 'root'
})
export class ManifestosService {

  private readonly baseUrl = 'http://localhost:8080/manifestos';

  constructor(private http: HttpClient) {}

  listar(): Observable<Manifesto[]> {
    return this.http.get<Manifesto[]>(this.baseUrl);
  }
}
