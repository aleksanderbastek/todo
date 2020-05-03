import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";

import { task } from "../task";

@Component({
  selector: "app-todo",
  templateUrl: "./todo.component.html",
  styleUrls: ["./todo.component.css"],
})
export class TodoComponent implements OnInit {
  tasks: task[];

  constructor(private api: ApiService) {}

  getTasks(): void {
    this.api.getTasks().subscribe((tasks) => (this.tasks = tasks));
  }

  ngOnInit(): void {
    this.getTasks();
  }
}
