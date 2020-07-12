import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { BoardComponent } from "./board/board.component";
import { StartComponent } from "./start/start.component";

const routes: Routes = [
	{
		path: "board/:id",
		component: BoardComponent,
		data: { title: "board list" },
	},
	{
		path: "",
		component: StartComponent,
		data: { title: "start" },
	},

	{ path: "", redirectTo: "", pathMatch: "full" },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
