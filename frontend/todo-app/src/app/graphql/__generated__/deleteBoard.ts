/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: deleteBoard
// ====================================================

export interface deleteBoard_deleteBoard {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface deleteBoard {
  deleteBoard: deleteBoard_deleteBoard;
}

export interface deleteBoardVariables {
  id: string;
}
