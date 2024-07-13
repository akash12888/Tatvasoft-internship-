import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

 

  constructor() {}

  login() {
    // Implement your login logic here
    console.log('Logging in...', this.username, this.password);
    // Example: You can call an authentication service to handle login
    // authService.login(this.username, this.password).subscribe(result => {
    //   console.log('Login successful', result);
    // }, error => {
    //   console.error('Login failed', error);
    // });
  }
}
