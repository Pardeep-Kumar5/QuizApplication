import { Category } from './../Class/category';
import { QuestionService } from './../Services/question.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AllServicesService } from '../Services/all.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  categoryId=sessionStorage.getItem('categoryId')
  StatusList:any[]=[];
  Data:any
  IsApproved:any

  CategoryList:Category[]=[];
   statusValues = this.StatusList.map((user) => user.status);

  constructor(private route:Router,
    private service:AllServicesService,
    private questionService:QuestionService,
    private toastr:ToastrService){}
    ngOnInit(){
      this.GetAllQuestion();
    }
   GetAllQuestion()
   {
    this.service.GetAllCategroy().subscribe(
      (Response)=>{
        this.CategoryList=Response
        console.log(Response)
      })
   }

    GetStatus(id:any)
    {
    sessionStorage.setItem('categoryId',id)
      let islogin=sessionStorage.getItem("isLoggedIn")
      if(islogin)
      {
 this.IsApproved=sessionStorage.getItem('status')
        if(this.IsApproved==='false'){
          this.toastr.success('Request have been sent to admin please wait for approvel','Success',{
            timeOut:2000,
            progressBar:true,
            progressAnimation:"decreasing"
          })
        }
        else
        {
           localStorage.setItem('questions', "");
          this.route.navigateByUrl('/quiz')
        }
      }
      else
      {
        this.toastr.error("You are not access to this ","",{
          timeOut:2000,
          progressBar:true,
          progressAnimation:"decreasing"
        })
        this.route.navigateByUrl('/login')
      }
    }
}
