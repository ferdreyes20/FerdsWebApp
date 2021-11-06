import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private activatedRoute: ActivatedRoute) {
  }
  ngOnInit(): void {
    let user: UserParams;

    this.activatedRoute.queryParams.subscribe(params => {
      let username = params['username'];
      let password = params['password'];

      user = {
        username,
        password
      } as UserParams;
    });

    this.http.post("api/Login/AuthUser", user).subscribe(
      (response: User) => {
        console.log({ "response": response });
        localStorage.setItem("ferdsUser", JSON.stringify(response));
      },
      (errors) => {
        console.log({ "errors": errors });
      }
    );
  }
}
