import { HttpClient, HttpClientModule, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterDTO } from '../models/RegisterDTO';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/LoginDTO';
import { Score } from '../models/score';

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
    sessionStorage.setItem("token", x.token);

  }

  async envoyerScore(inputScore : string, inputTemps : string): Promise<void>{
    let token = sessionStorage.getItem("token");
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer '+ token
      })
    };

    let scoreTrans = new Score(0,null, null, inputTemps, Number(inputScore), false );
    console.log(httpOptions);
    console.log(scoreTrans);
     let x = await lastValueFrom(this.http.post<any>("http://localhost:5221/api/Scores/PostScore", scoreTrans, httpOptions));
     console.log(x);
  }

}

