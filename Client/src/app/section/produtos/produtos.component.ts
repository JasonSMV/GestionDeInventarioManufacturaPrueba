import { Component, OnInit } from '@angular/core';
import { IProducto } from '../../models/producto';
import { ProdutosService } from '../../produtos.service';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrl: './produtos.component.css',
})
export class ProdutosComponent implements OnInit {
  productos: IProducto[];

  constructor(private productosService: ProdutosService) {}

  ngOnInit(): void {
    this.productosService.getProductos().subscribe((respuesta) => {
      this.productos = respuesta;
    });
  }
}
