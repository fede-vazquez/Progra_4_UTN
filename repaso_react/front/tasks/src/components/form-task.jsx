import { useTaskStore } from "../stores/tasks-store";

export default function FormTask() {
    const { addTask: add } = useTaskStore();

    const handleSubmit = e => {
        e.preventDefault();
        const form = e.target;
        const data = new FormData(form);
        const text = data.get("task");

        add(text);
        form.reset();
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
        </>
    );
}
