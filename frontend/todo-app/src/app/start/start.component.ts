import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

  constructor(private api: ApiService, private apollo: Apollo) { }

  ngOnInit(): void {
    // this.api.getHelloWorld();

    this.apollo
      .watchQuery({
        query: gql` {
    sayHelloWorld

}`,
      })
      .valueChanges
      .subscribe((data) => {
        console.log(data);
      });
  }
}
