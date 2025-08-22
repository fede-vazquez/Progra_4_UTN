import { useTasks } from "../hooks/use-tasks";
import Task from "./task";
import TaskList from "./task-list";

export default function FormTask() {
    const { tasks, addTask, completeTask, deleteTask } = useTasks();

    const handleSubmit = e => {
        e.preventDefault();
        const form = e.target;
        const data = new FormData(form);
        const text = data.get("task");
        addTask(text)
            .then(msg => {
                console.log(msg);
                form.reset();
            })
            .catch(err => console.error(err));
    };

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="task">Tarea:</label>
                    <input type="text" id="task" name="task" />
                </div>
                <button>Agregar</button>
            </form>
            <TaskList
                title="Tareas"
                tasks={tasks.filter(t => !t.completed)}
                completeTask={completeTask}
                deleteTask={deleteTask}
            />
            <TaskList
                title="Tareas completadas"
                tasks={tasks.filter(t => t.completed)}
                completeTask={completeTask}
                deleteTask={deleteTask}
            />
        </>
    );
}
