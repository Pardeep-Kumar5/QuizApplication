import { Component } from '@angular/core';
import { AllServicesService } from '../Services/all.service';
import { StudentScore } from '../Class/student-score';

@Component({
  selector: 'app-all-student-score',
  templateUrl: './all-student-score.component.html',
  styleUrls: ['./all-student-score.component.scss']
})
export class AllStudentScoreComponent {
  AllStudentSore:StudentScore[]=[];
  CSharpList:StudentScore[]=[];
  HtmlList:StudentScore[]=[];
  AngularList:StudentScore[]=[];
  constructor(private service:AllServicesService){}

  ngOnInit()
  {
    this.GetCSharp();
    this.GetHtml();
    this.GetAngular();
  }
  GetAllScore()
  {
    this.service.GetAllStudentScore().subscribe(
      (response)=>{
        this.AllStudentSore=response;
      })
  }
  GetCSharp()
  {
    this.service.GetCSharpScore().subscribe(
      (Response)=>{
this.CSharpList=Response
      })
  }
  GetHtml()
  {
    this.service.GetHtmlScore().subscribe(
      (Response)=>{
        this.HtmlList=Response
      })
  }
  GetAngular()
  {
    this.service.GetAngularScore().subscribe(
      (Response)=>{
        this.AngularList=Response
      })
  }
}
