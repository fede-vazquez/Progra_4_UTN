import { v4 as uuidv4 } from "uuid";
import { create } from "zustand";
import { persist } from "zustand/middleware";

const handler = set => ({
    tasks: [],

    addTask: text => {
        console.log(`Agrega la tarea: ${text}`);
        return set(state => ({
            tasks: [
                ...state.tasks,
                {
                    id: uuidv4(),
                    text,
                    completed: false,
                },
            ],
        }));
    },

    deleteTask: id => {
        console.log(`Eliminando la tarea con id: ${id}`);
        return set(({ tasks }) => {
            const filteredTasks = tasks.filter(t => t.id !== id);
            console.log(filteredTasks);
            return { tasks: filteredTasks };
        });
    },

    completeTask: id => {
        console.log(`Completando la tarea con el id: ${id}`);
        return set(({ tasks }) => {
            const tasksFound = tasks.find(t => t.id === id);
            tasksFound.completed = true;

            const updated = tasks.filter(t => t.id !== id);

            return { tasks: [...updated, tasksFound] };
        });
    },
});

export const useTaskStore = create(persist(handler, { name: "tasks-storage" }));
