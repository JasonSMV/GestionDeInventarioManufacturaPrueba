import { Component, OnInit } from '@angular/core';
import { IProducto } from './models/producto';
import { ProdutosService } from './produtos.service';
import { Observable } from 'rxjs';
import { CuentaService } from './cuenta/cuenta.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {}
