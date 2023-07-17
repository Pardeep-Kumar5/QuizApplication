import { Question } from './../Class/question';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private httpclient:HttpClient) { }

  GetAllQuestion():Observable<any>
  {
    return this.httpclient.get<any>('https://localhost:44324/Question/GetAllQuestions')
  }
  GetCSHARPquestion():Observable<any>{
    return this.httpclient.get<any>('https://localhost:44324/Question/GetAllCSharpQuestion')
  }
  GetHTMLQuestion():Observable<any>
  {
    return this.httpclient.get<any>('https://localhost:44324/Question/GetAllHTMLQuestion')
  }
  GetTypeScritpQuestions():Observable<any>
  {
    return this.httpclient.get<any>('https://localhost:44324/Question/GetAllTypeScriptQuestions')
  }
  AddQuestion(Que:Question):Observable<Question>
  {
    return this.httpclient.post<Question>('https://localhost:44324/Question/AddQuestion',Que)
  }
  UpdateQuestion(Que:Question):Observable<Question>
  {
   return this.httpclient.put<Question>('https://localhost:44324/Question/UpdateQuestion',Que) 
  }
}
