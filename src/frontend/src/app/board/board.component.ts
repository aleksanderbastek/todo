import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";
import { ActivatedRoute, Router } from "@angular/router";
import { getTodos_board_todos } from "../graphql/__generated__/getTodos";

import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { Observable } from "rxjs";
import { map, shareReplay } from "rxjs/operators";

import { DatePipe, formatDate } from "@angular/common";

import {
	MatDialog,
	MatDialogRef,
	MAT_DIALOG_DATA,
} from "@angular/material/dialog";
import { UpdateDialogComponent } from "../update-dialog/update-dialog.component";

@Component({
	selector: "app-board",
	templateUrl: "./board.component.html",
	styleUrls: ["./board.component.css"],
})
export class BoardComponent implements OnInit {
	boardId: string;
	todos: getTodos_board_todos[];
	dateNow = new Date();
	calendarDate = new Date(
		`${
			this.dateNow.getMonth() + 1
		} ${this.dateNow.getDate()} ${this.dateNow.getFullYear()}`
	);

	deadlineStyle = {
		color: "gray",
		fontSize: "10pt",
	};
	overDeadlineStyle = {
		color: "red",
		fontSize: "10pt",
	};
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
		private breakpointObserver: BreakpointObserver,
		public dialog: MatDialog
	) {}

	// !!!!!!!!!!!!!!!!!!!!!!!!!!! ZAPYTANIA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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

	getMyAllTodos() {
		this.getMyTodos(this.boardId, 30);
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
	// Zapytania: Todos with deadline

	getTodosWithDeadline() {
		this.api.getMyTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.todos.filter((t) => t.deadline);
		});
	}

	getTodosForToday() {
		this.api.getMyTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.todos.filter(
				(t) =>
					Date.parse(t.deadline) >= this.modifyDate(0).getTime() &&
					Date.parse(t.deadline) < this.modifyDate(1).getTime()
			);
		});
	}

	getTodosForTomorrow() {
		this.api.getMyTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.todos.filter(
				(t) =>
					Date.parse(t.deadline) >= this.modifyDate(1).getTime() &&
					Date.parse(t.deadline) < this.modifyDate(2).getTime()
			);
		});
	}

	getTodosForThisWeek() {
		this.api.getMyTodos(this.boardId, 30).subscribe((data: any) => {
			this.todos = data.data.board.todos.filter(
				(t) =>
					Date.parse(t.deadline) >= this.modifyDate(0).getTime() &&
					Date.parse(t.deadline) < this.modifyDate(7).getTime()
			);
		});
	}

	modifyDate(days) {
		return new Date(
			`${this.dateNow.getMonth() + 1} ${
				this.dateNow.getDate() + days
			} ${this.dateNow.getFullYear()}`
		);
	}

	parseToDate(date) {
		return new Date(date);
	}
	parseToNumber(date) {
		return Number(date);
	}

	// !!!!!!!!!!!!!!!!!!! Modyfikacje !!!!!!!!!!!!!!!!!!!!!!

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

	// Dialog

	openDialog(todoId$) {
		const i = this.todos.findIndex((t) => t.id === todoId$);
		const dialogRef = this.dialog.open(UpdateDialogComponent, {
			data: {
				todoId: todoId$,
				title: this.todos[i].title,
				deadline: this.todos[i].deadline,
			},
		});

		dialogRef.afterClosed().subscribe((result) => {
			if (result.title !== undefined) {
				this.todos[i].title = result.title;
				this.todos[i].deadline = result.deadline;
			}
		});
	}

	ngOnInit(): void {
		this.getMyId();
		this.getMyTodos(this.boardId, 30);
	}
}
// boardId: e3571312-90c2-41c1-9114-27f703fcccea
