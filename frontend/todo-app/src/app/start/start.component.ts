import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";
import { Apollo } from "apollo-angular";
import gql from "graphql-tag";

import { createBoard, createTodo, deleteBoard, deleteTodo, board, todo, markTodoAsDone, markTodoAsUndone } from "../graphql/mutations";
import { variable } from "@angular/compiler/src/output/output_ast";

@Component({
  selector: "app-start",
  templateUrl: "./start.component.html",
  styleUrls: ["./start.component.css"]
})
export class StartComponent implements OnInit {

  title = "five";

  constructor(private api: ApiService, private apollo: Apollo) { }

  ngOnInit(): void {

    this.apollo.mutate<any>({
      mutation: markTodoAsUndone,
      variables: {
        id: "1da8a6a4-e1a3-4c1f-ab65-18c13de4c212",
      },
    })
      .subscribe(
        (data: any) => console.log(data)
      );
    // this.api.getHelloWorld();
    /*

      }
            }`,
          })
          .valueChanges
          .subscribe((r: any) => {
            this.descrpt = r.data.board.id;
            console.log(r);
          });
        setTimeout(() => { console.log(this.descrpt) }, 500);
        */

  }

}
