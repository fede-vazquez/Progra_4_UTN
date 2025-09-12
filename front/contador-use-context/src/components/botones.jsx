import { useContext } from "react";
import { ContextoContador } from "../context/contexto-contador";

export default function Botones() {
    const { setContador } = useContext(ContextoContador);

    return (
        <div>
            <button onClick={() => setContador(prev => prev + 1)}>
                Aumentar
            </button>
            <button onClick={() => setContador(prev => prev - 1)}>
                Disminuir
            </button>
            <button onClick={() => setContador(0)}>Resetear</button>
        </div>
    );
}
