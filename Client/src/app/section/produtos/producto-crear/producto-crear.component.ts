import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProdutosService } from '../../../produtos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-producto-crear',
  templateUrl: './producto-crear.component.html',
  styleUrl: './producto-crear.component.css',
})
export class ProductoCrearComponent implements OnInit {
  productoForm: FormGroup;

  constructor(
    private productoService: ProdutosService,
    private router: Router
  ) {}

  limpiarProductoForm() {
    this.productoForm = new FormGroup({
      Nombre: new FormControl('', [Validators.required]),
      TipoDeElaboracionId: new FormControl('', [Validators.required]),
      EstadoId: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.limpiarProductoForm();
  }

  onSubmit() {
    debugger;
    this.productoService
      .crearProducto(this.productoForm.value)
      .subscribe(() => {
        console.log('Productor creado');
        this.router.navigate(['/productos']);
      });
  }
}
