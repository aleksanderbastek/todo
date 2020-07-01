/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: getDoneTodos
// ====================================================

export interface getDoneTodos_board_doneTodos {
  __typename: "TodoQueryType";
  id: string;
  title: string;
  deadline: any | null;
  creationDate: any;
  isDone: boolean;
  isExpired: boolean;
  doneDate: any | null;
}

export interface getDoneTodos_board {
  __typename: "BoardQueryType";
  doneTodos: (getDoneTodos_board_doneTodos | null)[];
}

export interface getDoneTodos {
  board: getDoneTodos_board | null;
}

export interface getDoneTodosVariables {
  id: string;
  take: number;
  skip?: number | null;
}
