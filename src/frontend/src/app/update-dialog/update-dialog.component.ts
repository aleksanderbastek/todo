import { Component, OnInit, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ApiService } from "../api.service";
import { NgModule } from "@angular/core";

@Component({
	selector: "app-update-dialog",
	templateUrl: "./update-dialog.component.html",
	styleUrls: ["./update-dialog.component.css"],
})
export class UpdateDialogComponent implements OnInit {
	constructor(
		private api: ApiService,
		public dialogRef: MatDialogRef<UpdateDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) {}

	onNoClick(): void {
		this.dialogRef.close();
	}

	updateMyTodo(todoId, title, deadline?) {
		this.api
			.updateMyTodo(todoId, title, deadline)
			.subscribe((data) => console.log(data));
	}

	ngOnInit(): void {}
}
