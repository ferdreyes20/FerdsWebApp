import { HttpClient } from '@angular/common/http';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  public user: UserParams;
  public errors: any;

  constructor(private httpClient: HttpClient, private router: Router ,private activatedRoute: ActivatedRoute) {
  }
  ngOnInit(): void {
    const currentUser = localStorage.getItem("ferdsUser");
    if (currentUser) {
      this.router.navigate(["/"]);
    }
  }

  login(form: NgForm) {

    this.user = {
      username : form.value.username,
      password :form.value.password
    } as UserParams;

    this.httpClient.post("api/Login/AuthUser", this.user).subscribe(
      (response: User) => {
        localStorage.setItem("ferdsUser", JSON.stringify(response));
        localStorage.setItem("ferdsJwt", response.token);

        this.router.navigate(["/"]);
      },
      (errors) => {
        if(errors.error.errors) {
          this.errors = errors.error.errors;
        } else {
          this.errors = 
            JSON.parse(errors.error.error);
        }
      }
    );
  }
}
