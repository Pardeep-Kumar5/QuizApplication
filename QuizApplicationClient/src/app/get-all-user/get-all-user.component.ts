import { Component } from '@angular/core';
import { RegisterService } from '../Services/register.service';
import { User } from '../Class/user';
import { AllServicesService } from '../Services/all.service';

@Component({
  selector: 'app-get-all-user',
  templateUrl: './get-all-user.component.html',
  styleUrls: ['./get-all-user.component.scss']
})
export class GetAllUserComponent {
  UserList:User[]=[];
  constructor(private registerservice:AllServicesService){}

  ngOnInit()
  {
    this.GetUser()
  }
  GetUser()
  {
    this.registerservice.GetRegister().subscribe(
      (Response)=>{
        this.UserList=Response
        console.log(Response)
      }
    )
  }
}
