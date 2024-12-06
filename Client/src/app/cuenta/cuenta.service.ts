import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CuentaService {
  baseUrl = 'https://localhost:5001/api/';

  private usuarioActual = new BehaviorSubject(null);
  usuarioActual$ = this.usuarioActual.asObservable();

  constructor(private http: HttpClient) {}

  login(values: any) {
    return this.http.post(this.baseUrl + 'cuenta/login', values).pipe(
      map((usuario: any) => {
        if (usuario) {
          localStorage.setItem('token', usuario.token);
          this.usuarioActual.next(usuario);
        }
      })
    );
  }
}
