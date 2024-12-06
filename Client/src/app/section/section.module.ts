import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutosComponent } from './produtos/produtos.component';
import { BrowserModule } from '@angular/platform-browser';
import { ProductoDetallesComponent } from './produtos/producto/producto-detalles/producto-detalles.component';
import { ProductoComponent } from './produtos/producto/producto.component';
import { RouterModule } from '@angular/router';
import { ProductoCrearComponent } from './produtos/producto-crear/producto-crear.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProdutosComponent,
    ProductoComponent,
    ProductoDetallesComponent,
    ProductoCrearComponent,
  ],
  imports: [CommonModule, BrowserModule, ReactiveFormsModule, RouterModule],
})
export class SectionModule {}
