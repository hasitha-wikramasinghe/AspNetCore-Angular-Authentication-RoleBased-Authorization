import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from '../models/user.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb:FormBuilder, private http:HttpClient) { }
  readonly baseURL = 'http://localhost:49631/api';

  // this is the object created by the help of user model
  // formModel: User = new User();


  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', Validators.required],
      ConfirmPassword: ['', Validators.required]
    })
  });

  register() {
    var body = {
      UserName : this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    }
    // console.log(body);

    return this.http.post(this.baseURL+'/ApplicationUser/register', body);

  }

  login(formData:any) {
    return this.http.post(this.baseURL+'/ApplicationUser/login', formData);
  }

  getUserProfile() {
    return this.http.get(this.baseURL+'/UserProfile');
  }

  roleMatch(allowedRoles:any): boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach((element:any) => {
      if(userRole == allowedRoles) {
        isMatch = true;
        // return false;
      } else {
        // return true;
        isMatch = false;
      }
    });
    return isMatch;
  }


}
