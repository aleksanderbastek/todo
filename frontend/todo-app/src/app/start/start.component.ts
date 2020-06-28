import { Component, OnInit } from "@angular/core";
import { createBoard } from "../graphql/__generated__/createBoard";
import { Router } from "@angular/router";
import { ApiService } from "../api.service";

import { Apollo } from "apollo-angular";

@Component({
	selector: "app-start",
	templateUrl: "./start.component.html",
	styleUrls: ["./start.component.css"],
})
export class StartComponent implements OnInit {
	constructor(private router: Router, private api: ApiService) {}

	gotoItems(id: string) {
		this.router.navigate(["/board", id]);
	}

	createMyBoard() {
		this.api.createMyBoard().subscribe((data: createBoard) => {
			const createdBoard: createBoard = data;
			this.gotoItems(createdBoard.data.createBoard.result.boardId);
		});
	}

	ngOnInit(): void {}
}
