import { useTaskStore } from "../stores/tasks-store";

export default function Task({ id, text, completed }) {
    const { completeTask: complete, deleteTask: del, tasks } = useTaskStore();
    return (
        <li key={id}>
            <span className={`${completed && "text-green-700"}`}>{text}</span>
            {!completed && (
                <input
                    type="checkbox"
                    id={id}
                    onClick={() => {
                        complete(id);
                        console.log(tasks);
                    }}
                />
            )}
            <button
                onClick={() => {
                    del(id);
                    console.log(tasks);
                }}
            >
                {" "}
                🗑
            </button>
        </li>
    );
}
