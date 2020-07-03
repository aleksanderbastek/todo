import gql from "graphql-tag";
// import { query } from '@angular/animations';

export const showBoard = gql`
	query showBoard($id: String!) {
		board(id: $id) {
			id
			title
			description
			creationDate
			numberOfTodos
			numberOfDoneTodos
			numberOfUndoneTodos
		}
	}
`;

export const getTodos = gql`
	query getTodos($id: String!, $take: Int!, $skip: Int) {
		board(id: $id) {
			todos(take: $take, skip: $skip) {
				id
				title
				deadline
				creationDate
				isDone
				isExpired
				doneDate
			}
		}
	}
`;

export const getDoneTodos = gql`
	query getDoneTodos($id: String!, $take: Int!, $skip: Int) {
		board(id: $id) {
			doneTodos(take: $take, skip: $skip) {
				id
				title
				deadline
				creationDate
				isDone
				isExpired
				doneDate
			}
		}
	}
`;

export const getUndoneTodos = gql`
	query getUndoneTodos($id: String!, $take: Int!, $skip: Int) {
		board(id: $id) {
			undoneTodos(take: $take, skip: $skip) {
				id
				title
				deadline
				creationDate
				isDone
				isExpired
				doneDate
			}
		}
	}
`;

export const getTodo = gql`
	query getTodo($id: String!) {
		todo(id: $id) {
			id
			title
			deadline
			creationDate
			isDone
			isExpired
			doneDate
		}
	}
`;

// nie dodałem właściwości board do wszystkich zapytań pobierających todo
