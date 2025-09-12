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

/*
Teoría

Los contextos, siguiendo una buena práctica, se crean a 3 archivos:
- 1er: El contexto propiamente dicho
- 2do: El proveedor del contexto
- 3ro: Un custom hook que manipula la funcionalidades (si las posee) del contexto
*/
