import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductoComponent } from './section/produtos/producto/producto.component';
import { ProductoDetallesComponent } from './section/produtos/producto/producto-detalles/producto-detalles.component';
import { ProdutosComponent } from './section/produtos/produtos.component';
import { LoginComponent } from './cuenta/login/login.component';
import { ProductoCrearComponent } from './section/produtos/producto-crear/producto-crear.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'cuenta/login',
    component: LoginComponent,
  },
  { path: 'productos', component: ProdutosComponent },
  { path: 'producto/crear', component: ProductoCrearComponent },
  { path: 'producto/:id', component: ProductoDetallesComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
