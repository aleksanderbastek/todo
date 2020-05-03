import { Injectable } from "@angular/core";

import { InMemoryDbService } from "angular-in-memory-web-api";
import { task } from "./task";

@Injectable({
  providedIn: "root",
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const tasks = [
      { id: 11, name: "Posprzatac dom" },
      { id: 12, name: "Zrobic objad" },
      { id: 13, name: "Zmyc naczynia" },
      { id: 14, name: "umyc kiebel" },
      { id: 15, name: "narabac drewno" },
      { id: 16, name: "aaa" },
    ];
    return { tasks };
  }

  genId(tasks: task[]): number {
    return tasks.length > 0
      ? Math.max(...tasks.map((task) => task.id)) + 1
      : 11;
  }
}
