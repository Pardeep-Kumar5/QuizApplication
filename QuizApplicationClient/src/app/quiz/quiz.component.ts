import { QuizService } from './../Services/quiz.service';
import { Component,OnInit  } from '@angular/core';
import { interval } from 'rxjs';
import { QuestionService } from '../Services/question.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent {

  categoryId=sessionStorage.getItem('categoryId')
  constructor(public quizService:QuizService,
    private router:Router,
    private toastr:ToastrService ){}

  ngOnInit() {
    debugger
   this.GetCategoryName();
    const data=sessionStorage.getItem("status")
    const catgegory=sessionStorage.getItem('categoryId')
    if(this.categoryId===null)
    {
      debugger
      this.toastr.info("Please Select Quiz Language !!","",{
        timeOut:2000,
        progressBar:true,
        progressAnimation:"decreasing"
       })
   this.router.navigateByUrl('home')
    }
    if(data==='false') {
      debugger
     this.toastr.info("You are not approved yet!!","",{
      timeOut:2000,
      progressBar:true,
      progressAnimation:"decreasing"
     })
 this.router.navigateByUrl('home')
     }
     else{
      const storedSeconds = localStorage.getItem('seconds');
      const storedQnProgress = localStorage.getItem('qnProgress');
      const storedQuestions = localStorage.getItem('questions');
      if (storedSeconds && storedQnProgress && storedQuestions) {
        this.quizService.seconds = parseInt(storedSeconds, 10);
        this.quizService.qnProgress = parseInt(storedQnProgress, 10);
        this.quizService.questions = JSON.parse(storedQuestions);
        if (this.quizService.qnProgress === 10) {
          this.router.navigate(['/result']);
        } else {
          this.startTimer();
        }
      } else {
        this.quizService.seconds = 0;
        this.quizService.qnProgress = 0;
    
        this.quizService.getQuestions(this.categoryId).subscribe(
          (data: any) => {
            this.quizService.questions = data;
            localStorage.setItem('questions', JSON.stringify(data));
            this.startTimer();
          })
        ;}
     }
  }
 
  GetCategoryName()
   {
     this.quizService.GetCategoryName(this.categoryId).subscribe(
       (Response)=>{
         sessionStorage.setItem("CategoryName",Response.category)
       }
     )
   }
  startTimer() {
    this.quizService.timer = setInterval(() => {
      this.quizService.seconds++;
      localStorage.setItem('seconds', this.quizService.seconds.toString());
    }, 1000);
  }


  Answer(qID:any, choice:any) {
    this.quizService.questions[this.quizService.qnProgress].answer = choice;
    localStorage.setItem('questions', JSON.stringify(this.quizService.questions));
    localStorage.setItem('score',JSON.stringify(this.quizService.Score));
    this.quizService.qnProgress++;
    localStorage.setItem('qnProgress', this.quizService.qnProgress.toString());
    if (this.quizService.qnProgress == 10) {
      clearInterval(this.quizService.timer);
      this.router.navigate(['/result']);
    }
  }
}