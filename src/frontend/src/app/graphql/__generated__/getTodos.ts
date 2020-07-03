/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: getTodos
// ====================================================

export interface getTodos_board_todos {
  __typename: "TodoQueryType";
  id: string;
  title: string;
  deadline: any | null;
  creationDate: any;
  isDone: boolean;
  isExpired: boolean;
  doneDate: any | null;
}

export interface getTodos_board {
  __typename: "BoardQueryType";
  todos: (getTodos_board_todos | null)[];
}

export interface getTodos {
  board: getTodos_board | null;
}

export interface getTodosVariables {
  id: string;
  take: number;
  skip?: number | null;
}
