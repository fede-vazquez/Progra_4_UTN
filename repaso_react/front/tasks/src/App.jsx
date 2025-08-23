import FormTask from "./components/form-task";
import TaskList from "./components/task-list";
import TaskProvider from "./contexts/tasks/provider";

function App() {
    return (
        <>
            <h1>App de Tareas</h1>
            <TaskProvider>
                <FormTask />
                <TaskList title="Tareas:" />
                <TaskList title="Tareas completadas:" completed />
            </TaskProvider>
        </>
    );
}

export default App;
