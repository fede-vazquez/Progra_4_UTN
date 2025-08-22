import { useTasks } from "../hooks/use-tasks";

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
            <ul>
                {tasks?.map(t => (
                    <li key={t.id}>
                        <span className={`${t.completed && "text-green-700"}`}>
                            {t.text}
                        </span>
                        {!t.completed && (
                            <input
                                type="checkbox"
                                id={t.id}
                                onClick={() => completeTask(t.id)}
                            />
                        )}
                        <button onClick={() => deleteTask(t.id)}> 🗑</button>
                    </li>
                ))}
            </ul>
        </>
    );
}
