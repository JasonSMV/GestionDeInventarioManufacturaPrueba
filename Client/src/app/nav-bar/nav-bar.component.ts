import { Component, OnInit } from '@angular/core';
import { CuentaService } from '../cuenta/cuenta.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css',
})
export class NavBarComponent implements OnInit {
  usuarioActual$: Observable<any>;

  constructor(private cuentaService: CuentaService) {}
  ngOnInit(): void {
    this.usuarioActual$ = this.cuentaService.usuarioActual$;
  }
}
