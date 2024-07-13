import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  toggleForm() {
    throw new Error('Method not implemented.');
  }
  user: any = {
    firstName: '',
    lastName: '',
    email: '',
    password: ''
  };
  confirmPassword: string = '';

  constructor() { }

  submitForm() {
    if (this.confirmPassword !== this.user.password) {
      alert("Passwords do not match.");
      return;
    }

    // Handle form submission logic here (e.g., API call, data processing)
    console.log(this.user);
    // Reset the form after submission (optional)
    // this.user = {}; 
    // this.confirmPassword = '';
  }

  get passwordMismatch() {
    return this.user.password !== this.confirmPassword;
  }
}
