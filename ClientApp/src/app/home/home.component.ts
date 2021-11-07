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
  public user: User;

  constructor(private httpClient: HttpClient, private router: Router) {

   }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem("ferdsUser")) as User;
    if(!this.user) {
      this.router.navigate(["login"]);
    }

    this.getTerritories();
  }

  getTerritories(): void {
    var token = localStorage.getItem("ferdsJwt");
    let headersOptions = new HttpHeaders()
      .set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${token}`);

    this.httpClient.get("/api/Home", { headers: headersOptions }).subscribe(
      (response: any) => {
        this.territories = response.data;
      },
      (errors) => {
        console.log({ "Home errors ": errors });
      }
    );
  }

  logout(): void 
  {
    localStorage.removeItem("ferdsUser");
    localStorage.removeItem("ferdsJwt");

    this.router.navigate(["login"]);
  }
}
