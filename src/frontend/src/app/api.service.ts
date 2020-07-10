import { Injectable } from "@angular/core";
import { Apollo } from "apollo-angular";
import {
	createBoard,
	createTodo,
	deleteTodo,
	markTodoAsUndone,
	markTodoAsDone,
	todo,
} from "./graphql/mutations";
import {
	getTodos,
	getTodo,
	getDoneTodos,
	getUndoneTodos,
} from "./graphql/queries";
import { variable } from "@angular/compiler/src/output/output_ast";

@Injectable({
	providedIn: "root",
})
export class ApiService {
	constructor(private apollo: Apollo) {}

	// zapytania

	getMyTodo(apiId: string) {
		return this.apollo.query<any>({
			query: getTodo,
			variables: {
				id: apiId,
			},
		});
	}

	getMyTodos(apiId: string, take$: number) {
		return this.apollo.query<any>({
			fetchPolicy: "network-only",
			query: getTodos,
			variables: {
				id: apiId,
				take: take$,
			},
		});
	}

	// mutacje

	createMyBoard() {
		return this.apollo.mutate<any>({
			mutation: createBoard,
			variables: {
				title: "lista domyslna",
			},
		});
	}

	createMyTodo(apiId: string, name: string) {
		return this.apollo.mutate<any>({
			mutation: createTodo,
			variables: {
				boardId: apiId,
				title: name,
			},
		});
	}

	deleteMyTodo(apiId: string) {
		return this.apollo.mutate<any>({
			mutation: deleteTodo,
			variables: {
				id: apiId,
			},
		});
	}

	markMyTodoAsDone(apiId: string) {
		return this.apollo.mutate<any>({
			mutation: markTodoAsDone,
			variables: {
				id: apiId,
			},
		});
	}

	markMyTodoAsUndone(apiId: string) {
		return this.apollo.mutate<any>({
			mutation: markTodoAsUndone,
			variables: {
				id: apiId,
			},
		});
	}

	getMyDoneTodos(apiId: string, take$: number) {
		return this.apollo.mutate<any>({
			mutation: getDoneTodos,
			variables: {
				id: apiId,
				take: take$,
			},
		});
	}

	getMyUndoneTodos(apiId: string, take$: number) {
		return this.apollo.mutate<any>({
			mutation: getUndoneTodos,
			variables: {
				id: apiId,
				take: take$,
			},
		});
	}

	updateMyTodo(todoId: string, title$?: string, deadline$?: Date) {
		return this.apollo.mutate<any>({
			mutation: todo,
			variables: {
				id: todoId,
				title: title$,
				deadline: deadline$,
			},
		});
	}
}
