import Task from "./task";

export default function TaskList({ title, tasks, completeTask, deleteTask }) {
    return (
        <section className="border border-black p-2">
            <h3>{title}</h3>
            <ul>
                {tasks?.map(t => (
                    <Task
                        key={t.id}
                        onComplete={() => {
                            completeTask(t.id);
                        }}
                        onDelete={() => {
                            deleteTask(t.id);
                        }}
                        {...t}
                    />
                ))}
            </ul>
        </section>
    );
}
