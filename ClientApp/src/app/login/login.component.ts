import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  constructor(private httpClient: HttpClient, private router: Router ,private activatedRoute: ActivatedRoute) {
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

    this.httpClient.post("api/Login/AuthUser", user).subscribe(
      (response: User) => {
        console.log({ "response": response });
        localStorage.setItem("ferdsUser", JSON.stringify(response));
        localStorage.setItem("ferdsJwt", response.token);

        debugger;
        this.router.navigate(["/"]);
      },
      (errors) => {
        console.log({ "errors": errors });
      }
    );
  }
}
