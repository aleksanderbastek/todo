/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: createBoard
// ====================================================

export interface createBoard_createBoard_result {
	__typename: "CreateNewBoardResult";
	boardId: string | null;
}

export interface createBoard_createBoard {
	__typename: "MutationResultOfCreateNewBoardResult";
	isSuccessfull: boolean;
	errorReason: string | null;
	result: createBoard_createBoard_result | null;
}

export interface createBoard {
	data: any;
	createBoard: createBoard_createBoard;
}

export interface createBoardVariables {
	title: string;
	description?: string | null;
}
