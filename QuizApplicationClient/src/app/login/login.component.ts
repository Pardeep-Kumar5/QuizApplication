import { Component } from '@angular/core';
import { LoginService } from '../Services/login.service';
import { Login } from '../Class/login';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  login: Login = new Login();
  constructor(private loginservice:LoginService,
    private toastr:ToastrService,
    private router:Router){}

    logincheck() {
    this.loginservice.LoginUser(this.login).subscribe(
      (Response:any) => {
        this.toastr.success("Login Successfully","",{
          timeOut:2000,
          progressAnimation:"decreasing",
          progressBar:true
        });
        this.router.navigateByUrl("/home");
      },(error)=>{
        debugger;
        this.toastr.error("Please Enter a valid password and username","",{
          timeOut:2000,
          progressBar:true,
          progressAnimation:"decreasing"
        })
      }
)};
}