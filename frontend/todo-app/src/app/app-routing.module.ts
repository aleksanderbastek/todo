import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { BoardComponent } from "./board/board.component";
import { TodoComponent } from "./todo/todo.component";
import { StartComponent } from "./start/start.component";

const routes: Routes = [
	{
		path: "board",
		component: BoardComponent,
		data: { title: "Board" },
	},
	{
		path: "todo/:id",
		component: TodoComponent,
		data: { title: "todo list" },
	},
	{
		path: "start",
		component: StartComponent,
		data: { title: "start" },
	},

	{ path: "", redirectTo: "/start", pathMatch: "full" },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
