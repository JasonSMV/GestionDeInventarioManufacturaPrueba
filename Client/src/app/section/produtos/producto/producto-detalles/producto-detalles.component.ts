import { Component, OnInit } from '@angular/core';
import { IProducto } from '../../../../models/producto';
import { ProdutosService } from '../../../../produtos.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-producto-detalles',
  templateUrl: './producto-detalles.component.html',
  styleUrl: './producto-detalles.component.css',
})
export class ProductoDetallesComponent implements OnInit {
  producto: IProducto;

  constructor(
    private productService: ProdutosService,
    private activateRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cargarProducto();
  }

  cargarProducto() {
    this.productService
      .getProducto(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe((product) => {
        this.producto = product;
      });
  }

  borrarProducto(id: number) {
    if (confirm('borrar este producto?')) {
      this.productService.borrarProducto(id).subscribe(() => {
        console.log('Producto borrado');

        this.router.navigate(['/productos']);
      });
    }
  }
}
