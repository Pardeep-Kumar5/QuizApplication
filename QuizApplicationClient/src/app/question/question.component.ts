import { Component } from '@angular/core';
import { Question } from '../Class/question';
import { QuestionService } from '../Services/question.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
  columnsToDisplay = ['userName', 'age'];
  CSharpList:Question[]=[];
  HtmlList:Question[]=[];
  TypeScriptList:Question[]=[];
  displayedColumns: string[] = ['QuestionText', 'OptionOne','Optiontwo','Optionthree','OptionFour','Answer'];
  newQuestion=new Question;
  EditQuestion:Question=new Question();
  constructor(private questionservice:QuestionService){}

  ngOnInit()
  {
    this.GetCSharp();
    this.GetHtml();
  this.GetTypeScript();
  }
  GetCSharp()
  {
    this.questionservice.GetCSHARPquestion().subscribe(
      (Response)=>{
        this.CSharpList=Response;
      },
      (error)=>{
        console.log(error);
      }
    );
  }
  GetHtml()
  {
    this.questionservice.GetHTMLQuestion().subscribe(
      (Response)=>{
        this.HtmlList=Response
      })
  }
  GetTypeScript()
  {
    this.questionservice.GetTypeScritpQuestions().subscribe(
      (Response)=>{
        this.TypeScriptList=Response;
        console.log(Response)
      }
    )
  }
  SaveQuestion()
  {
    this.questionservice.AddQuestion(this.newQuestion).subscribe(
      (response)=>{
        this.GetCSharp();
        this.GetHtml();
  this.GetTypeScript();
        this.newQuestion.questionText="";
        this.newQuestion.option1="";
        this.newQuestion.option2="";
        this.newQuestion.option3="";
        this.newQuestion.option4="";
        this.newQuestion.answer="";
      },(error)=>{
        alert("Something went wrong while saving the record")
      }
    )
  }
  editClick(ques:Question)
  {
  this.EditQuestion=ques;
  }
  UpdateQuestion()
  {
    this.questionservice.UpdateQuestion(this.EditQuestion).subscribe(
      (response)=>{
        this.GetCSharp();
        this.GetHtml();
        this.GetTypeScript();
      },
      (error)=>{
        alert("Something went wrong while updating the record");
      }
    )
  }
}
