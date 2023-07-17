import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../Class/login';
import { Observable, map } from 'rxjs';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUserName:any
  currentuser:any
  constructor(private httpclient:HttpClient,
    private route:Router,
    private JwtHelperService:JwtHelperService
    ) { }

  LoginUser(login:Login):Observable<Login>
  {
    return this.httpclient.post<Login>("https://localhost:44324/Register/Login"
    ,login).pipe(map (u=>{
      if(u)
      {
        this.currentuser=u.name;
       sessionStorage.setItem('isLoggedIn','true');
        sessionStorage["currentuser"]=JSON.stringify(u);
       sessionStorage['registerId']=JSON.stringify( u.id);
       sessionStorage['role']=JSON.stringify(u.role); 
       sessionStorage['status']=JSON.stringify(u.status); 
       sessionStorage['participant']=JSON.stringify(u.name); 
      }
      return u;
    }))
  }

  Logout()
  {
    this.currentUserName="";
    sessionStorage.removeItem('isLoggedIn')
    localStorage.removeItem('qnProgress')
    localStorage.removeItem('questions');
    sessionStorage.removeItem('participant');
    sessionStorage.removeItem("currentuser");
    sessionStorage.removeItem("registerId");
    localStorage.removeItem('seconds');
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("CategoryName");
    sessionStorage.removeItem("status");
    sessionStorage.removeItem("categoryId");
    this.route.navigateByUrl("/login");
  }
  public isAuthenticated()
  {
    if(this.JwtHelperService.isTokenExpired())
    {
      return false;
    }
    else
    {
      return true;
    }
  }
}
