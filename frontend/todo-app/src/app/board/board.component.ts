import { Component, OnInit } from "@angular/core";
import { task } from "../task";
import { ApiService } from "../api.service";

@Component({
  selector: "app-board",
  templateUrl: "./board.component.html",
  styleUrls: ["./board.component.css"]
})
export class BoardComponent implements OnInit {

  boardlist: task[];

  constructor(private api: ApiService) { }

  // do zainspirowania się

  /*
  getBoard(): void {
    this.api.getBoard().subscribe(board => this.boardlist = board);
  }
  */
  ngOnInit(): void {

  }

}
