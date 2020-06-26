import { Component, OnInit } from "@angular/core";
import { Apollo } from "apollo-angular";
import gql from "graphql-tag";

import { variable } from "@angular/compiler/src/output/output_ast"; // nie pamiętam do czego to
import { createBoard } from "../graphql/__generated__/createBoard";
import { Router } from "@angular/router";
import { ApiService } from "../api.service";

@Component({
	selector: "app-start",
	templateUrl: "./start.component.html",
	styleUrls: ["./start.component.css"],
})
export class StartComponent implements OnInit {
	constructor(private router: Router, private api: ApiService) {}

	gotoItems(id: string) {
		this.router.navigate(["/todo", id]);
	}

	createMyBoard() {
		this.api.createMyBoard().subscribe((data: createBoard) => {
			const createdBoard: createBoard = data;
			this.gotoItems(createdBoard.data.createBoard.result.boardId);
		});
	}

	ngOnInit(): void {}
}
