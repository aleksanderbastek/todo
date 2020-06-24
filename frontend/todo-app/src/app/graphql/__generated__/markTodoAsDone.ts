/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: markTodoAsDone
// ====================================================

export interface markTodoAsDone_todo_markTodoAsDone {
  __typename: "MutationResultOfMarkTodoAsDoneResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface markTodoAsDone_todo {
  __typename: "TodoMutationType";
  markTodoAsDone: markTodoAsDone_todo_markTodoAsDone;
}

export interface markTodoAsDone {
  todo: markTodoAsDone_todo;
}

export interface markTodoAsDoneVariables {
  id: string;
}
