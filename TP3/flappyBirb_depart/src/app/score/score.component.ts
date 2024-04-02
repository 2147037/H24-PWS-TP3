import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { MyServiceService } from '../services/MyService.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public service : MyServiceService) { }

  async ngOnInit() : Promise<void>{

    this.userIsConnected = sessionStorage.getItem("token") != null;

    this.publicScores = await this.service.getPubScores();
    this.myScores = await this.service.getMyScores();



  }

  async changeScoreVisibility(score : Score){
    
    if(score.id!=null)
    this.service.changeVisibility(score.id);

    score.isPublic = !score.isPublic;

  }

}
