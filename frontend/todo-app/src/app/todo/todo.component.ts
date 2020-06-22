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

	constructor(private api: ApiService) { }

	// do zainspirowania się

	/*
    getTasks(): void {
      this.api.getTasks().subscribe((tasks) => (this.tasks = tasks));
    }

    addTask(name: string): void {
      name = name.trim();
      if (!name) {
        return;
      }
      this.api.addTask({ name } as task).subscribe((task) => {
        this.tasks.push(task);
      });
    }
    deleteTask(Task: task): void {
      this.tasks = this.tasks.filter(t => t !== Task);
      this.api.deleteTask(Task).subscribe();
    }
    */
	ngOnInit(): void {
	}
}
