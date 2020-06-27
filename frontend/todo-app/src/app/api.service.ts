import { Injectable } from "@angular/core";
import { Apollo } from "apollo-angular";
import { createBoard, createTodo, deleteTodo } from "./graphql/mutations";
import { getTodos, getTodo } from "./graphql/queries";

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
}
