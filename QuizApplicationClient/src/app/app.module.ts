import { MatTableModule } from '@angular/material/table';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { JwtModule } from '@auth0/angular-jwt';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { QuestionComponent } from './question/question.component';
import { JwtinterceptorService } from './Services/jwtinterceptor.service';
import { AddTeacherComponent } from './add-teacher/add-teacher.component';
import { QuizComponent } from './quiz/quiz.component';
import { ResultComponent } from './result/result.component';
import { StudentScoreComponent } from './student-score/student-score.component';
import { AllStudentScoreComponent } from './all-student-score/all-student-score.component';
import { StatusComponent } from './status/status.component';
import { ToastRef } from 'ngx-toastr';
import {MatCardModule} from '@angular/material/card'
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { GetAllUserComponent } from './get-all-user/get-all-user.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    QuestionComponent,
    AddTeacherComponent,
    QuizComponent,
    ResultComponent,
    StudentScoreComponent,
    AllStudentScoreComponent,
    StatusComponent,
    GetAllUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatCardModule,
MatTableModule,
MatSlideToggleModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>{
          return sessionStorage.getItem("currentuser")?
          JSON.parse(sessionStorage.getItem("currentuser")as string).token:null;
      }
    }
    }),
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtinterceptorService,
    
      multi:true

      },
      provideAnimations(),
      // providetoastr(),
      ],
 
  
  bootstrap: [AppComponent]
})
export class AppModule { }
