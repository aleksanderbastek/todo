/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: todo
// ====================================================

export interface todo_todo_updateTitle {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface todo_todo_updateDeadline {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface todo_todo_markTodoAsDone {
  __typename: "MutationResultOfMarkTodoAsDoneResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface todo_todo_markTodoAsUndone {
  __typename: "MutationResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface todo_todo {
  __typename: "TodoMutationType";
  updateTitle: todo_todo_updateTitle;
  updateDeadline: todo_todo_updateDeadline;
  markTodoAsDone: todo_todo_markTodoAsDone;
  markTodoAsUndone: todo_todo_markTodoAsUndone;
}

export interface todo {
  todo: todo_todo;
}

export interface todoVariables {
  id: string;
  title: string;
  deadline?: any | null;
  doneDate?: any | null;
}
