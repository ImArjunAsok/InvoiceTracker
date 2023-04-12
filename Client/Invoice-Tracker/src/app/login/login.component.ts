import { Component, ViewChild, ElementRef, OnInit, AfterViewInit } from '@angular/core';
import { MicrosoftAuthService } from '../services/microsoft-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements AfterViewInit {
  @ViewChild('loginButton', { static: true }) loginButton: ElementRef = {} as ElementRef;

  constructor(private authService: MicrosoftAuthService) { }

  ngAfterViewInit() {
    this.loginButton.nativeElement.addEventListener('click', (event: any) => {
      event.preventDefault();
      this.authService.login();
    });
  }
}

