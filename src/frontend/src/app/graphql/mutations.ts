import gql from "graphql-tag";

// POST
export const createBoard = gql`
	mutation createBoard($title: String!, $description: String) {
		createBoard(title: $title, description: $description) {
			isSuccessfull
			errorReason

			result {
				boardId
			}
		}
	}
`;

export const createTodo = gql`
	mutation createTodo($boardId: String!, $title: String!, $deadline: DateTime) {
		createTodo(boardId: $boardId, deadline: $deadline, title: $title) {
			isSuccessfull
			errorReason

			result {
				todoId
			}
		}
	}
`;

// DELETE

export const deleteBoard = gql`
	mutation deleteBoard($id: String!) {
		deleteBoard(id: $id) {
			isSuccessfull
			errorReason
		}
	}
`;

export const deleteTodo = gql`
	mutation deleteTodo($id: String!) {
		deleteTodo(id: $id) {
			isSuccessfull
			errorReason
		}
	}
`;

// PUT

export const board = gql`
	mutation board($id: String!, $title: String!, $description: String) {
		board(id: $id) {
			updateBoardTitle(title: $title) {
				isSuccessfull
				errorReason
			}
			updateBoardDescription(description: $description) {
				isSuccessfull
				errorReason
			}
		}
	}
`;

export const todo = gql`
	mutation todo(
		$id: String!
		$title: String!
		$deadline: DateTime
		$doneDate: DateTime
	) {
		todo(id: $id) {
			updateTitle(title: $title) {
				isSuccessfull
				errorReason
			}
			updateDeadline(deadline: $deadline) {
				isSuccessfull
				errorReason
			}
			markTodoAsDone(doneDate: $doneDate) {
				isSuccessfull
				errorReason
			}
			markTodoAsUndone(doneDate: $doneDate) {
				isSuccessfull
				errorReason
			}
		}
	}
`;

export const markTodoAsDone = gql`
	mutation markTodoAsDone($id: String!) {
		todo(id: $id) {
			markTodoAsDone {
				isSuccessfull
				errorReason
			}
		}
	}
`;

export const markTodoAsUndone = gql`
	mutation markTodoAsUndone($id: String!) {
		todo(id: $id) {
			markTodoAsUndone {
				isSuccessfull
				errorReason
			}
		}
	}
`;
