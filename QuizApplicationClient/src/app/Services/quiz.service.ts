import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from '../Class/question';
import { JsonPipe } from '@angular/common';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  readonly rootUrl = 'https://localhost:44324/';
 public questions: any=[];
 categoryId=sessionStorage.getItem('categoryId')
  seconds: any;
  timer:any;
  qnProgress: any;
  Score: any = 0;

  constructor(private http: HttpClient) { }
  displayTimeElapsed() {
    return Math.floor(this.seconds / 3600) + ':' + Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60);
  }

  getQuestions(categoryId:any) {
    return this.http.get(this.rootUrl + 'Quiz/GetQuiz?categoryId='+categoryId);
  }
  getAnswers() {
    var body = this.questions.map((x:any) => x.questionId);
    return this.http.post(this.rootUrl + 'Quiz/Answer',body);
  }
  GetCategoryName(categoryid:any)
  {
    return this.http.get<any>(this.rootUrl+'Category/GetCategorybyId?categoryId='+categoryid)
  } 

  submitScore() {
    debugger;
    var body = {
      registerId: sessionStorage.getItem('registerId'),
     categoryId:sessionStorage.getItem('categoryId'),
      Score: this.Score,
      TimeSpent: this.seconds
    };
    return this.http.post(this.rootUrl + 'Score/StudentScore', body);
  }

  getParticipantName()
  {
    var body=JSON.parse(sessionStorage.getItem('participant')as string);
    return body;
  }
  GetCategoryNameBySesstion()
  {
    var body=sessionStorage.getItem("CategoryName")
    return body;
  }
}