import { Component, OnInit } from "@angular/core";
import { ApiService } from "../api.service";
import { Apollo } from "apollo-angular";
import gql from "graphql-tag";

import { createBo } from "../graphql/mutations";
import { variable } from "@angular/compiler/src/output/output_ast";

@Component({
  selector: "app-start",
  templateUrl: "./start.component.html",
  styleUrls: ["./start.component.css"]
})
export class StartComponent implements OnInit {

  title: String = "fourth";

  constructor(private api: ApiService, private apollo: Apollo) { }

  ngOnInit(): void {

    const dupa = gql`
      query dupa {

      }

    `;

    this.apollo;

    this.apollo.mutate<any>({
      mutation: createBo,
      variables: {
        title: this.title,
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
