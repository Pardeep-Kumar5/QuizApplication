import { Component } from '@angular/core';
import { AllServicesService } from '../Services/all.service';
import { User } from '../Class/user';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.scss']
})
export class StatusComponent {
  StatusApprove=new User;
  StatusUnApprove=new User;
  StatusList:User[]=[];
  constructor(public service:AllServicesService,
    private route:Router){}

  IsPanding:any
  ngOnInit(): void 
  {
   this.GetStatus();
  }

  GetStatus()
  {
    this.service.GetRegister().subscribe(
      (Response)=>{
        this.StatusList=Response
        console.log(Response);
      })
  }
  ApproveClick(id:any)
  {
    this.service.ApproveStaus(id).subscribe(
      (Response)=>{
      this.GetStatus();
      },
      (error)=>{
        alert("Something went wrong")
      })
  }

  UnApproveClick(id:any)
  {
    debugger;
    this.service.UnApproveStatus(id).subscribe(
    (Response)=>{
      this.GetStatus();
    },
    (error)=>{
      alert("Something went wrong")
    })
  }
}
