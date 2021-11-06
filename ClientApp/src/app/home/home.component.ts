import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Territory } from '../_models/territory';
import { User } from '../_models/user';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public territories: Territory[] = [];

  constructor(private httpClient: HttpClient, private router: Router) { }

  ngOnInit(): void {
    var currentUser = JSON.parse(localStorage.getItem("ferdsUser")) as User;

    if (!currentUser) {
      this.router.navigateByUrl('/Login');
    };


    let headersOptions = new HttpHeaders()
      .set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${currentUser.token}`);


    debugger;
    this.httpClient.get("/api/Home", { headers: headersOptions }).subscribe(
      (response: Territory[]) => {
        console.log({ "territories": response });
      },
      (error) => {
        console.log({ "Home error ": error });
      }
    );
  }
}
