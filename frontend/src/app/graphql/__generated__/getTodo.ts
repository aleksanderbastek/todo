/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: getTodo
// ====================================================

export interface getTodo_todo {
  __typename: "TodoQueryType";
  id: string;
  title: string;
  deadline: any | null;
  creationDate: any;
  isDone: boolean;
  isExpired: boolean;
  doneDate: any | null;
}

export interface getTodo {
  todo: getTodo_todo | null;
}

export interface getTodoVariables {
  id: string;
}
