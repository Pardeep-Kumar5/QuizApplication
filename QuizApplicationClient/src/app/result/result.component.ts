import { Component } from '@angular/core';
import { QuizService } from '../Services/quiz.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent {

  correctAnswerCount: any = 0;
  constructor(public quizService: QuizService, private router: Router) { }

  ngOnInit() {
    if (parseInt(localStorage.getItem('qnProgress')as string) == 10) {
      this.quizService.seconds = parseInt(localStorage.getItem('seconds')as string);
      this.quizService.qnProgress = parseInt(localStorage.getItem('qnProgress')as string);
      this.quizService.questions = JSON.parse(localStorage.getItem('questions')as string);
      this.quizService.getAnswers().subscribe(
        (data: any) => {
          console.log(data)
          this.quizService.Score = 0;
          this.quizService.questions.forEach((e:any, i:any) => {
            if (e.answer == data[i])
              this.quizService.Score++;
            e.correct = data[i];
          });
        }
      );
    }
    else
      this.router.navigate(['/quiz']);
  }

  OnSubmit() {
    debugger
    this.quizService.submitScore().subscribe(() => {
      this.router.navigateByUrl('/studentscore')
    });
  }

  restart() {
    localStorage.setItem('qnProgress', "0");
    localStorage.setItem('questions', "");
    localStorage.removeItem('seconds');
    localStorage.setItem('score',"0");
    this.router.navigate(['/quiz']);
  }
}
