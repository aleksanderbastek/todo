import { Component, OnInit, Inject, Input } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ApiService } from "../api.service";

@Component({
	selector: "app-update-dialog",
	templateUrl: "./update-dialog.component.html",
	styleUrls: ["./update-dialog.component.css"],
})
export class UpdateDialogComponent implements OnInit {
	minDate = new Date();

	constructor(
		private api: ApiService,
		public dialogRef: MatDialogRef<UpdateDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) {}

	updateMyTodo(todoId, title, deadline?) {
		this.data.deadline = deadline._validSelected;
		this.api
			.updateMyTodo(todoId, title, deadline._validSelected)
			.subscribe((date) => console.log(date));
	}
	onNoClick(): void {
		this.dialogRef.close();
	}

	ngOnInit(): void {
		this.minDate.setDate(this.minDate.getDate() + 1);
	}
}
