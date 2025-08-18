import { useState } from "react";
import { isNullOrEmpty } from "../utils/string-validation";

export default function FormTask() {
    const [tasks, setTasks] = useState([]);

    const handleSubmit = e => {
        e.preventDefault();

        const data = new FormData(e.target);
        const text = data.get("task");

        if (isNullOrEmpty(text)) return;

        const taskFound = tasks.find(
            t => t.text == text.trim() && t.completed == false
        );

        if (taskFound && !taskFound.completed) return;
        const task = {
            id: new Date(),
            text,
            completed: false,
        };

        setTasks(prev => [...prev, task]);

        e.target.reset();
    };

    const handleSwitchComplete = id => {
        const taskFound = tasks.find(t => t.id == id);
        taskFound.completed = true;

        const updatedTasks = tasks.filter(t => t.id != id);

        setTasks([...updatedTasks, taskFound]);
    };

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="task">Tarea:</label>
                    <input type="text" id="task" name="task" />
                </div>
                <button className="cursor-pointer">Agregar</button>
                <button
                    onClick={() => {
                        console.log(tasks);
                    }}
                    className="cursor-pointer"
                >
                    Tareas
                </button>
            </form>
            <ul>
                {tasks?.map(task => (
                    <li
                        key={task.id}
                        className={`${task.completed && "text-green-500"}`}
                    >
                        {task.text}
                        {!task.completed && (
                            <input
                                type="checkbox"
                                id={task.id}
                                onClick={() => handleSwitchComplete(task.id)}
                            />
                        )}
                    </li>
                ))}
            </ul>
        </>
    );
}
