import { Component, OnInit } from "@angular/core";
import { Apollo } from "apollo-angular";
import gql from "graphql-tag";

import { createBoard } from "../graphql/mutations";

import { variable } from "@angular/compiler/src/output/output_ast"; // nie pamiętam do czego to
import { createBoard as boardC } from "../graphql/__generated__/createBoard";
import { Router } from "@angular/router";

@Component({
	selector: "app-start",
	templateUrl: "./start.component.html",
	styleUrls: ["./start.component.css"],
})
export class StartComponent implements OnInit {
	constructor(private apollo: Apollo, private router: Router) {}

	gotoItems(id: string) {
		this.router.navigate(["/todo", id]);
	}

	createBoard() {
		this.apollo
			.mutate<any>({
				mutation: createBoard,
				variables: {
					title: "lista domyslna",
				},
			})
			.subscribe((data: any) => {
				const createdBoard: boardC = data;
				this.gotoItems(createdBoard.data.createBoard.result.boardId);
			});
	}

	ngOnInit(): void {}
}
