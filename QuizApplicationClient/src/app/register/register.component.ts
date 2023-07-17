import { Component } from '@angular/core';
import { RegisterService } from '../Services/register.service';
import { User } from '../Class/user';
import { Router } from '@angular/router';
import { Question } from '../Class/question';
import { QuestionService } from '../Services/question.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
newregister=new User;
  constructor(private registerservice:RegisterService,
    private router:Router){}

      SaveClick()
      {
        this.registerservice.studentRegister(this.newregister).subscribe(
          (response)=>{
       // this.Getall();
        this.newregister.name="";
        this.newregister.address="";
        this.newregister.email="";
        this.newregister.password="";
        this.router.navigateByUrl('/login')
          }
        )
      }
      
  }
