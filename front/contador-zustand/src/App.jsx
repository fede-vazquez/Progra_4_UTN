import { useEffect } from "react";
import Botones from "./components/Botones";
import DisplayContador from "./components/display-contador";
import { useUserStore } from "./stores/contador";

function App() {
    const { usuarios, cargarUsuarios } = useUserStore();

    useEffect(() => {
        cargarUsuarios();
    }, []);

    return (
        <>
            <DisplayContador />
            <Botones />

            <h2>Usuarios</h2>

            <ul>
                {usuarios.length === 0 && <p>Cargando usuarios</p>}

                {usuarios &&
                    usuarios.map(usuario => (
                        <li key={usuario.id}>{usuario.name}</li>
                    ))}
            </ul>
        </>
    );
}

export default App;
