import { Injectable } from '@angular/core';
import { Role } from '../Class/role';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { JwtActiveguardServiceService } from './jwt-activeguard-service.service';

@Injectable({
  providedIn: 'root'
})
export class RolegaurdService {

  roles:Role=new Role()
  constructor(private router:Router,
    private jwthelper:JwtActiveguardServiceService){}
  canActivate(route:ActivatedRouteSnapshot,state:RouterStateSnapshot):boolean{
    const user=sessionStorage.getItem('role') as string;
    const users=JSON.parse(user)
    this.roles.role=users;
    const isAuthrized=this.roles.role===(route.data['role']);
    if(!isAuthrized)
    {
      alert("Only Admin can access this page ")
      };
      return false;
    }
  }

