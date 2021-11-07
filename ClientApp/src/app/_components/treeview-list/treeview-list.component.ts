import { Component, Input, OnInit } from "@angular/core";
import { Territory } from "src/app/_models/territory";

@Component({
  selector: 'treeview-list',
  templateUrl: './treeview-list.component.html',
})
export class TreeviewListComponent implements OnInit {
  @Input() currentTerritory: Territory;

  public hideChildren: boolean = false;

  constructor() {
   }

  ngOnInit(): void {
  }
}
