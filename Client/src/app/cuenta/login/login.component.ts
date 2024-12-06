import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CuentaService } from '../cuenta.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private cuentaService: CuentaService) {}

  limpiarLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      contrasena: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.limpiarLoginForm();
  }

  onSubmit() {
    this.cuentaService.login(this.loginForm.value).subscribe(() => {
      console.log('Usuario inicio session');
    });
  }
}
