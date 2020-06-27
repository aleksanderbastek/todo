import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";
import { Apollo } from "apollo-angular";
import { getTodos_board_todos } from "../graphql/__generated__/getTodos";

@Component({
	selector: "app-todo",
	templateUrl: "./todo.component.html",
	styleUrls: ["./todo.component.css"],
})
export class TodoComponent implements OnInit {
	boardId: string;
	todos: getTodos_board_todos[];
	constructor(
		private route: ActivatedRoute,
		private location: Location,
		private api: ApiService,
		private apollo: Apollo
	) {}

	// zapytania
	getMyId() {
		this.boardId = this.route.snapshot.paramMap.get("id");
	}

	getMyTodos(id$: string, take$: number) {
		this.api.getMyTodos(id$, take$).subscribe((data: any) => {
			this.todos = data.data.board.todos;
		});
	}

	getMyTodo(id$: string) {
		return this.api.getMyTodo(id$);
	}

	// mutacje

	createMyTodo(name: string) {
		name = name.trim();
		if (!name) {
			return;
		}
		this.api.createMyTodo(this.boardId, name).subscribe((todoP: any) => {
			const todoId: string = todoP.data.createTodo.result.todoId;

			this.getMyTodo(todoId).subscribe((todo) => {
				this.todos.push(todo.data.todo);
			});
		});
	}

	deleteMyTodo(todoId: string) {
		this.api.deleteMyTodo(todoId).subscribe();
		this.todos = this.todos.filter((t) => t.id !== todoId);
	}

	ngOnInit(): void {
		this.getMyId();
		this.getMyTodos(this.boardId, 30);
	}
}
