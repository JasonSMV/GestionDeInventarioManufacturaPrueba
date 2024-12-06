import { Component, Input } from '@angular/core';
import { IProducto } from '../../../models/producto';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrl: './producto.component.css',
})
export class ProductoComponent {
  @Input() producto: IProducto;
}
