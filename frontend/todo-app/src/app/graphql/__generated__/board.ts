/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: board
// ====================================================

export interface board_board_updateBoardTitle {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface board_board_updateBoardDescription {
  __typename: "MutationResult";
  isSuccessfull: boolean;
}

export interface board_board {
  __typename: "BoardMutationType";
  updateBoardTitle: board_board_updateBoardTitle;
  updateBoardDescription: board_board_updateBoardDescription;
}

export interface board {
  board: board_board;
}

export interface boardVariables {
  id: string;
  title: string;
  description?: string | null;
}
