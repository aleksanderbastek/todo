/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: markTodoAsUndone
// ====================================================

export interface markTodoAsUndone_todo_markTodoAsUndone {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface markTodoAsUndone_todo {
  __typename: "TodoMutationType";
  markTodoAsUndone: markTodoAsUndone_todo_markTodoAsUndone;
}

export interface markTodoAsUndone {
  todo: markTodoAsUndone_todo;
}

export interface markTodoAsUndoneVariables {
  id: string;
}
