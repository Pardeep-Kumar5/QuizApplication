import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { QuestionComponent } from './question/question.component';
import { AddTeacherComponent } from './add-teacher/add-teacher.component';
import { QuizComponent } from './quiz/quiz.component';
import { JwtActiveguardServiceService } from './Services/jwt-activeguard-service.service';
import { ResultComponent } from './result/result.component';
import { StudentScore } from './Class/student-score';
import { StudentScoreComponent } from './student-score/student-score.component';
import { AllStudentScoreComponent } from './all-student-score/all-student-score.component';
import { RolegaurdService } from './Services/rolegaurd.service';
import { StatusComponent } from './status/status.component';
import { GetAllUserComponent } from './get-all-user/get-all-user.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"home",component:HomeComponent},
  {path:"register",component:RegisterComponent},
  {path:"login",component:LoginComponent},
  {path:"result",component:ResultComponent},
  {path:"status",component:StatusComponent},
  {path:"user",component:GetAllUserComponent},
  {path:"studentscore",component:StudentScoreComponent,canActivate:[JwtActiveguardServiceService]},
  {path:"allscore",component:AllStudentScoreComponent,canActivate:[JwtActiveguardServiceService]},
  {path:"question",component:QuestionComponent,canActivate:[JwtActiveguardServiceService]},
  {path:"addteacher",component:AddTeacherComponent,canActivate:[JwtActiveguardServiceService]},
  {path:"quiz",component:QuizComponent,canActivate:[JwtActiveguardServiceService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
