import { Component, Input, OnInit, ViewEncapsulation } from "@angular/core";
import { Territory } from "src/app/_models/territory";

@Component({
  selector: 'list',
  templateUrl: './list.component.html',
  styleUrls: ["list.component.css"],
  encapsulation: ViewEncapsulation.None
})
export class ListComponent implements OnInit {
  @Input() territories: Territory[] = [];

  public hideChildren: boolean = false;

  constructor() {
   }

  ngOnInit(): void {
  }
}
