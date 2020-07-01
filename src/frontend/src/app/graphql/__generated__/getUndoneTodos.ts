/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: getUndoneTodos
// ====================================================

export interface getUndoneTodos_board_undoneTodos {
  __typename: "TodoQueryType";
  id: string;
  title: string;
  deadline: any | null;
  creationDate: any;
  isDone: boolean;
  isExpired: boolean;
  doneDate: any | null;
}

export interface getUndoneTodos_board {
  __typename: "BoardQueryType";
  undoneTodos: (getUndoneTodos_board_undoneTodos | null)[];
}

export interface getUndoneTodos {
  board: getUndoneTodos_board | null;
}

export interface getUndoneTodosVariables {
  id: string;
  take: number;
  skip?: number | null;
}
