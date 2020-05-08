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
  private boardUrl = "api/board";

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
  constructor(private http: HttpClient) { }

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

  deleteTask(Task: task | number): Observable<task> {
    const id = typeof Task === "number" ? Task : Task.id;
    const url = `${this.tasksUrl}/${id}`;

    return this.http.delete<task>(url, this.httpOptions).pipe(
      tap((_) => console.log(`deleted task id = ${id}`)),
      catchError(this.handleError<task>("deleteTask"))
    );
  }

  getBoard(): Observable<task[]> {
    return this.http.get<task[]>(this.boardUrl).pipe(
      tap((_) => console.log("fetched board")),
      catchError(this.handleError<task[]>("getBoard", []))
    );
  }
}
