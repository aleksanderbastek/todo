import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { BoardComponent } from "./board/board.component";
import { TodoComponent } from "./todo/todo.component";

const routes: Routes = [
  {
    path: "board",
    component: BoardComponent,
    data: { title: "Board" },
  },
  {
    path: "todo",
    component: TodoComponent,
    data: { title: "todo list" },
  },
  { path: "", redirectTo: "/board", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
