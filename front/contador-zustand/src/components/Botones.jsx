import { useCountStore } from "../stores/contador";

export default function Botones() {
    const { aumentarContador, disminuirContador, resetearContador } =
        useCountStore();

    return (
        <div>
            <button onClick={() => aumentarContador()}>Aumentar</button>
            <button onClick={() => disminuirContador()}>Disminuir</button>
            <button onClick={() => resetearContador()}>Resetear</button>
        </div>
    );
}
