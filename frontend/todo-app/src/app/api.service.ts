import { Injectable } from "@angular/core";

import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable, of } from "rxjs";
import { catchError, map, tap } from "rxjs/operators";

import { task } from "./task";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  private tasksUrl = "api/tasks";

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
  constructor(private http: HttpClient) {}

  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getTasks(): Observable<task[]> {
    return this.http.get<task[]>(this.tasksUrl).pipe(
      tap((_) => console.log("fetched tasks")),
      catchError(this.handleError<task[]>("getTasks", []))
    );
  }
  addTask(Task: task): Observable<task> {
    return this.http.post<task>(this.tasksUrl, Task, this.httpOptions).pipe(
      tap((newTask: task) =>
        console.log(`added task ${newTask.id} ${newTask.name}`)
      ),
      catchError(this.handleError<task>("addTask"))
    ); //dodawanie zadań
  }
}
