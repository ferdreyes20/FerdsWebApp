import { Component, Input, OnInit } from "@angular/core";
import { Territory } from "src/app/_models/territory";

@Component({
  selector: 'list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  @Input() territories: Territory[] = [];

  public hideChildren: boolean = false;

  constructor() {
   }

  ngOnInit(): void {
  }
}
