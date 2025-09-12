import { isNullOrEmpty } from "../utils/string-validation";
import { useArray } from "./use-array";
import { v4 as uuidv4 } from "uuid";

export const useTasks = (initialValue = []) => {
    const {
        array: tasks,
        addItem,
        deleteOrUpdateItem,
    } = useArray(initialValue);

    const addTask = text => {
        return new Promise((resolve, reject) => {
            if (isNullOrEmpty(text)) return reject("Invalid task");

            const taskFound = tasks.find(
                t => t.text == text.trim() && t.completed == false
            );
            if (taskFound) return reject("task already added or not completed");

            const task = {
                id: uuidv4(),
                text,
                completed: false,
            };
            addItem(task);
            resolve("Task added!");
        });
    };

    const completeTask = id => {
        const taskFound = tasks.find(t => t.id == id);
        taskFound.completed = true;

        deleteOrUpdateItem("id", id, taskFound);
    };

    const deleteTask = id => {
        deleteOrUpdateItem("id", id);
    };

    return { tasks, addTask, completeTask, deleteTask };
};
