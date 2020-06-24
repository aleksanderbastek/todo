import { Component, OnInit } from "@angular/core";
import { task } from "../task";

@Component({
	selector: "app-board",
	templateUrl: "./board.component.html",
	styleUrls: ["./board.component.css"],
})
export class BoardComponent implements OnInit {
	boardlist: task[];

	constructor() {}

	ngOnInit(): void {}
}
