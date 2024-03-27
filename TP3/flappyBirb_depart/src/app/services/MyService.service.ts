import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterDTO } from '../models/RegisterDTO';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/LoginDTO';

@Injectable({
  providedIn: 'root'
})
export class MyServiceService {

constructor(public http :HttpClient) { }

  async register(username : string, email : string , pw : string, pwConfirm : string) : Promise<void>{
    let registerDTO = new RegisterDTO(username, email, pw, pwConfirm)

    let x = await lastValueFrom(this.http.post<any>("http://localhost:5221/api/Users/Register", registerDTO));
    console.log(x);
  }

  async login(username : string, pw : string) : Promise<void>{
    let loginDTO = new LoginDTO(username, pw);
    let x = await lastValueFrom(this.http.post<any>("http://localhost:5221/api/Users/Login", loginDTO));
    console.log(x);
    localStorage.setItem("token", x.token);

  }

}

