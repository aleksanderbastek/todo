import { Injectable } from "@angular/core";

import { InMemoryDbService } from "angular-in-memory-web-api";
import { task } from "./task";

@Injectable({
  providedIn: "root",
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const tasks = [
      { id: 1, name: "Posprzatac dom" },
      { id: 2, name: "Zrobic objad" },
      { id: 3, name: "Zmyc naczynia" },
      { id: 4, name: "umyc kiebel" },
      { id: 5, name: "narabac drewno" },
      { id: 666, name: "aaa" },
    ];
    const board = [
      { id: 1, name: "plan dnia" },
      { id: 2, name: "konkretne" },
      { id: 3, name: "programowanie" },
      { id: 4, name: "studia" },
    ];
    return { tasks, board };
  }


  genIdforTasks(tasks: task[]): number {
    return tasks.length > 0
      ? Math.max(...tasks.map((task) => task.id)) + 1
      : 1;
  }
  genIdforBoard(board: task[]): number {
    return board.length > 0
      ? Math.max(...board.map((b) => b.id)) + 1
      : 1;
  }
}
