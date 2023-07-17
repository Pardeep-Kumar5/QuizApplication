import { interval } from 'rxjs';
import { Component } from '@angular/core';
import { StudentScore } from '../Class/student-score';
import { AllServicesService } from '../Services/all.service';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-student-score',
  templateUrl: './student-score.component.html',
  styleUrls: ['./student-score.component.scss']
})
export class StudentScoreComponent {
 studentScoreList:StudentScore[]=[];
 registerId=sessionStorage.getItem("registerId");
  constructor(private Service:AllServicesService)  {}
  ngOnInit()
  {
   this.GetScoreByRegisterId();
  }

  GetScoreByRegisterId()
  {
    this.Service.GetStudentScoreById(this.registerId).subscribe(
      (response)=>{
        this.studentScoreList=response
        console.log(RegisterComponent)
      },
      (error)=>{
        alert("something went wrong while access data")
      }
    )
  }
}
