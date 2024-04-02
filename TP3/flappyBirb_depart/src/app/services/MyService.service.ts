import { HttpClient, HttpClientModule, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterDTO } from '../models/RegisterDTO';
import { last, lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/LoginDTO';
import { Score } from '../models/score';

@Injectable({
  providedIn: 'root'
})
export class MyServiceService {
  domain : string = "http://localhost:5221/api"

constructor(public http :HttpClient) { }
  listMyScore : Score[]= [];
  listPubScore : Score[] = [];

  async register(username : string, email : string , pw : string, pwConfirm : string) : Promise<void>{
    let registerDTO = new RegisterDTO(username, email, pw, pwConfirm)

    let x = await lastValueFrom(this.http.post<any>(this.domain + "/Users/Register", registerDTO));
    console.log(x);
  }

  async login(username : string, pw : string) : Promise<void>{
    let loginDTO = new LoginDTO(username, pw);
    let x = await lastValueFrom(this.http.post<any>(this.domain + "/Users/Login", loginDTO));
    console.log(x);
    sessionStorage.setItem("token", x.token);

  }

  async envoyerScore(inputScore : string, inputTemps : string): Promise<void>{
    

    let scoreTrans = new Score(0,null, null, inputTemps, Number(inputScore), false );
     let x = await lastValueFrom(this.http.post<any>(this.domain +"/Scores/PostScore", scoreTrans));
     console.log(x);
  }

  async getMyScores():Promise<Score[]>{
    this.listMyScore = [];
    let x = await lastValueFrom(this.http.get<any>(this.domain + "/Scores/GetMyScores"))
    console.log(x);
    for(let i =0; i < x.length; i++){
      let score = new Score(x[i].id, null, x[i].date, x[i].timeInSeconds, x[i].scoreValue,x[i].isPublic);
      this.listMyScore.push(score);
    }
    return this.listMyScore;
  }

  async getPubScores():Promise<Score[]>{
    this.listPubScore = [];
    let x = await lastValueFrom(this.http.get<any>(this.domain + "/Scores/GetPublicScores"))
    console.log(x);
    for(let i =0; i < x.length; i++){
      let score = new Score(x[i].id, x[i].pseudo, x[i].date, x[i].timeInSeconds, x[i].scoreValue,false);
      this.listPubScore.push(score);
    }
    return this.listPubScore;
  }

  async changeVisibility(id : number) : Promise<void>{
    let x = await lastValueFrom(this.http.put<any>(this.domain + "/Scores/ChangeScoreVisibility/" + id, id))
    console.log(x);
  }

}

