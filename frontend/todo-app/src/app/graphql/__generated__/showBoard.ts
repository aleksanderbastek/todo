/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: showBoard
// ====================================================

export interface showBoard_board {
  __typename: "BoardQueryType";
  id: string;
  title: string;
  description: string | null;
  creationDate: any;
  numberOfTodos: number;
  numberOfDoneTodos: number;
  numberOfUndoneTodos: number;
}

export interface showBoard {
  board: showBoard_board | null;
}

export interface showBoardVariables {
  id: string;
}
