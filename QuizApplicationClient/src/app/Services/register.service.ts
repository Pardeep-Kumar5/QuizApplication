import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Class/user';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';


@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient) { }

  studentRegister(ss:User):Observable<User>
  {
    debugger
    return this.httpclient.post<User>('https://localhost:44324/Register/Student',ss)
  }
  TeacherRegister(teacher:User):Observable<User>
  {
    debugger
    return this.httpclient.post<User>('https://localhost:44324/Register/Teacher',teacher)
  }
  GetAllRegister()
  {
    return this.httpclient.get<any>('https://localhost:44324/Register/GetRegister')
  }
}
