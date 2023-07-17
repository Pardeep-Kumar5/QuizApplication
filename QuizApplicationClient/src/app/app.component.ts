import { Component } from '@angular/core';
import { LoginService } from './Services/login.service';
import { NavigationEnd, Router } from '@angular/router';
import { QuizService } from './Services/quiz.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'QuizApplicationClient';
  isLoggedIn:boolean=true
  IsAdmin:any
  IsTeacher:any
  constructor(private loginservice:LoginService,
    public quizservice:QuizService,
    private router:Router){}


  ngOnInit(): void {
    this.router.events.subscribe(event=>{
      this.isLoggedIn=sessionStorage.getItem('isLoggedIn')==='true';
      if(event instanceof NavigationEnd)
      {
        let roleAdmin=sessionStorage.getItem('role')
        this.IsAdmin=roleAdmin==='"Admin"';
        let roleTeacher=sessionStorage.getItem('role')
        this.IsTeacher=roleTeacher==='"Teacher"'
      }
    })
  }
  LogoutClick()
  {
    this.loginservice.Logout();
  }
}
