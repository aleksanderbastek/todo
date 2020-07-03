/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: createTodo
// ====================================================

export interface createTodo_createTodo {
  __typename: "MutationResultOfAddNewTodoResult";
  isSuccessfull: boolean;
  errorReason: string | null;
}

export interface createTodo {
  createTodo: createTodo_createTodo;
}

export interface createTodoVariables {
  boardId: string;
  title: string;
  deadline?: any | null;
}
