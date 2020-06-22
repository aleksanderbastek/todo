import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { MatSliderModule } from "@angular/material/slider";
import { MatListModule } from "@angular/material/list";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";

import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";



import { BoardComponent } from "./board/board.component";
import { TodoComponent } from "./todo/todo.component";
import { StartComponent } from "./start/start.component";

import { GraphQLModule } from "./graphql.module";
import { ApolloModule, APOLLO_OPTIONS } from "apollo-angular";
import { HttpLinkModule, HttpLink } from "apollo-angular-link-http";
import { InMemoryCache } from "apollo-cache-inmemory";

@NgModule({
	declarations: [AppComponent, BoardComponent, TodoComponent, StartComponent],
	imports: [
		BrowserModule,
		AppRoutingModule,
		BrowserAnimationsModule,
		MatSliderModule,
		MatListModule,
		HttpClientModule,
		MatInputModule,
		MatButtonModule,
		MatIconModule,
		MatCardModule,

		ApolloModule,
		HttpLinkModule,
		GraphQLModule,
	],
	providers: [{
		provide: APOLLO_OPTIONS,
		useFactory: (httpLink: HttpLink) => ({
			cache: new InMemoryCache(),
			link: httpLink.create({
				uri: "http://localhost:5000/graphql",
				method: "POST" // Wywalić ten post w razie czego
			})
		}),
		deps: [HttpLink]
	}],
	bootstrap: [AppComponent],
})
export class AppModule { }
