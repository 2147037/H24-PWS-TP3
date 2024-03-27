import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MyServiceService } from '../services/MyService.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, public service : MyServiceService) { }

  ngOnInit() {
  }

  async login() : Promise<void>{
    await this.service.login(this.loginUsername, this.loginPassword);

    // Redirection si la connexion a réussi :
    this.route.navigate(["/play"]);
  }

  async register() : Promise<void>{
    await this.service.register(this.registerUsername, this.registerEmail, this.registerPassword, this.registerPasswordConfirm);
  }

}
