import {task} from "./task";

export function setLocalStorage(key, value) {
        if (localStorage.getItem(key) === null) { localStorage.setItem(key, JSON.stringify(value) ); }
        return JSON.parse(localStorage.getItem(key));
    }
export function updateLocalStorageTasks(key, tasks: task[]): void {
        localStorage.setItem(key, JSON.stringify(tasks) );
    }
