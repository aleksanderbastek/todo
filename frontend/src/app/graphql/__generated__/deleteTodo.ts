/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: deleteTodo
// ====================================================

export interface deleteTodo_deleteTodo {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface deleteTodo {
  deleteTodo: deleteTodo_deleteTodo;
}

export interface deleteTodoVariables {
  id: string;
}
