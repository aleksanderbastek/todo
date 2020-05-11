import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { MatSliderModule } from "@angular/material/slider";
import { MatListModule } from "@angular/material/list";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from '@angular/material/card';

import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { HttpClientInMemoryWebApiModule } from "angular-in-memory-web-api"; //api
import { InMemoryDataService } from "./in-memory-data.service";

import { BoardComponent } from "./board/board.component";
import { TodoComponent } from "./todo/todo.component";
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [AppComponent, BoardComponent, TodoComponent, MainComponent],
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
    HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
      dataEncapsulation: false,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
