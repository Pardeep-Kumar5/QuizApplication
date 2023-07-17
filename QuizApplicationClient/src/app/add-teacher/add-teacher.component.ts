import { User } from './../Class/user';
import { Component } from '@angular/core';
import { RegisterService } from '../Services/register.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.scss']
})
export class AddTeacherComponent {

  newregister=new User;
  constructor (private registerservice:RegisterService,
    private toastr:ToastrService){}

  TeacherRegister()
  {
    this.registerservice.TeacherRegister(this.newregister).subscribe(
      (response)=>{
        debugger
   // this.Getall();
    this.newregister.name="";
    this.newregister.address="";
    this.newregister.email="";
    this.newregister.password="";
      },(error)=>{
        this.toastr.warning("Enter the proper detail");
      }
    )
  }

}
