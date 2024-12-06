import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducto } from './models/producto';

@Injectable({
  providedIn: 'root',
})
export class ProdutosService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}

  getProductos() {
    return this.http.get<IProducto[]>(this.baseUrl + 'productos');
  }

  getProducto(id: number) {
    return this.http.get<IProducto>(`${this.baseUrl}productos/${id}`);
  }

  getEstado(id: number) {
    return this.http.get(`${this.baseUrl}estado/${id}`);
  }

  crearProducto(producto: any) {
    return this.http.post(this.baseUrl + 'productos', producto);
  }

  borrarProducto(id: number) {
    return this.http.delete(`${this.baseUrl}productos/${id}`);
  }
}
