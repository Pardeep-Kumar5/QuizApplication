import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { JwtActiveguardServiceService } from './jwt-activeguard-service.service';
import { Role } from '../Class/role';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { User } from '../Class/user';

@Injectable({
  providedIn: 'root'
})
export class AllServicesService {

  URL='https://localhost:44324/';
  constructor(private http:HttpClient,
    private Login:LoginService,
    private router:Router,
    private jwthelper:JwtActiveguardServiceService
    ) { }
    GetAllCategroy():Observable<any>
    {
    return this.http.get<any>(this.URL+"Category/GetAllCategory")
    }
  GetAllStudentScore():Observable<any>
  {
    return this.http.get<any>(this.URL+'Score/GetScore');
  }
  GetStudentScoreById(registerId:any):Observable<any>
  {
    return this.http.get<any>(this.URL+'Score/RegisterById?RegisterID='+registerId)
  }
  GetRegisterById(registerId:any):Observable<any>
  {
    return this.http.get<any>(this.URL+"Register/GetRegisterById?userID="+registerId)
  }                                  
  GetRegister():Observable<any>
  {
    return this.http.get<any>(this.URL+"Register/GetRegister")
  }
 ApproveStaus(registerId:User):Observable<User>
 {
  return this.http.put<User>(this.URL+"Register/ApproveStatus?registerId="+registerId,null)
 }
 UnApproveStatus(registerId:User):Observable<User>
 {
  return this.http.put<User>(this.URL+'Register/UnApproveStatus?registerId='+registerId,null)
 }
 GetCSharpScore()
 {
  return this.http.get<any>(this.URL+'Score/CSharpScore')
 }
 GetHtmlScore()
 {
  return this.http.get<any>(this.URL+'Score/GetHtmlScore')
 }
 GetAngularScore()
 {
  return this.http.get<any>(this.URL+'Score/GetAngularScore');
 }
}
