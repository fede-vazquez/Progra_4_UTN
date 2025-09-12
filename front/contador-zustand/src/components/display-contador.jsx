import { useCountStore } from "../stores/contador";

export default function DisplayContador() {
    const contador = useCountStore(state => state.contador);

    return <h2>Contador: {contador}</h2>;
}
