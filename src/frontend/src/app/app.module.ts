import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { MatSliderModule } from "@angular/material/slider";
import { MatListModule } from "@angular/material/list";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";

import { LayoutModule } from "@angular/cdk/layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatSidenavModule } from "@angular/material/sidenav";

import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { BoardComponent } from "./board/board.component";
import { StartComponent } from "./start/start.component";

import { GraphQLModule } from "./graphql.module";
import { ApolloModule, APOLLO_OPTIONS } from "apollo-angular";
import { HttpLinkModule, HttpLink } from "apollo-angular-link-http";
import { InMemoryCache } from "apollo-cache-inmemory";
import { environment } from "src/environments/environment";
import { MatDialogModule } from "@angular/material/dialog";
import { UpdateDialogComponent } from "./update-dialog/update-dialog.component";
import { FormsModule } from "@angular/forms";

@NgModule({
	declarations: [
		AppComponent,
		BoardComponent,
		StartComponent,
		UpdateDialogComponent,
	],
	entryComponents: [UpdateDialogComponent],
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
		MatDialogModule,
		MatToolbarModule,
		MatSidenavModule,

		ApolloModule,
		HttpLinkModule,
		GraphQLModule,
		LayoutModule,
		FormsModule,
	],
	providers: [
		{
			provide: APOLLO_OPTIONS,
			useFactory: (httpLink: HttpLink) => ({
				cache: new InMemoryCache(),
				link: httpLink.create({
					uri: environment.graphqlUrl,
					method: "POST", // Wywalić ten post w razie czego
				}),
			}),
			deps: [HttpLink],
		},
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
