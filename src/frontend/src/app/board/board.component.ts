import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Location } from "@angular/common";
import { Apollo } from "apollo-angular";
import { getTodos_board_todos } from "../graphql/__generated__/getTodos";

import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { Observable } from "rxjs";
import { map, shareReplay } from "rxjs/operators";

@Component({
	selector: "app-board",
	templateUrl: "./board.component.html",
	styleUrls: ["./board.component.css"],
})
export class BoardComponent implements OnInit {
	boardId: string;
	todos: getTodos_board_todos[];
	isHandset$: Observable<boolean> = this.breakpointObserver
		.observe(Breakpoints.Handset)
		.pipe(
			map((result) => result.matches),
			shareReplay()
		);
	constructor(
		private route: ActivatedRoute,
		private router: Router,
		private api: ApiService,
		private location: Location,
		private apollo: Apollo, // a to mi do testów potrzebne
		private breakpointObserver: BreakpointObserver
	) {}

	// zapytania
	getMyId() {
		this.boardId = this.route.snapshot.paramMap.get("id");
	}
	goBack(): void {
		this.router.navigate(["/start"]);
	}

	getMyTodos(id: string, take: number) {
		this.api.getMyTodos(id, take).subscribe((data: any) => {
			this.todos = data.data.board.todos;
		});
	}

	getMyTodo(id: string) {
		return this.api.getMyTodo(id);
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

	markMyTodo(id: string, isDone: boolean) {
		const i = this.todos.findIndex((t) => t.id === id);
		if (isDone === true) {
			this.api.markMyTodoAsUndone(id).subscribe();
			this.todos[i].isDone = false;
		} else if (isDone === false) {
			this.api.markMyTodoAsDone(id).subscribe();
			this.todos[i].isDone = true;
		}
	}
	getMyAllTodos() {
		location.reload();
	}

	getMyDoneTodos() {
		this.api.getMyDoneTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.doneTodos;
		});
	}

	getMyUndoneTodos() {
		this.api.getMyUndoneTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.undoneTodos;
		});
	}

	ngOnInit(): void {
		this.getMyId();
		this.getMyTodos(this.boardId, 30);
	}
}
// boardId: 2a9a5417-c784-4457-bf78-c24e5c101dad
