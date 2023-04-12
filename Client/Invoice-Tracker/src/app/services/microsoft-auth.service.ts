import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MicrosoftAuthService {

  constructor(private router: Router, private http: HttpClient) { }

  login() {
    this.http.get('/api/Account/ExternalLogin?provider=Microsoft', { observe: 'response' })
      .subscribe((res) => {
        if (res.status === 200) {
          window.location.href = '/api/Account/ExternalLogin?provider=Microsoft';
        }
      });
  }

  completeLogin() {
    this.http.post('/api/Account/ExternalLoginCallback', null, { observe: 'response' })
      .subscribe((res) => {
        if (res.status === 200) {
          console.log("completeLogin");
          
        }
      });
  }
}
