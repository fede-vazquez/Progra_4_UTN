import { useStore } from "../stores/contador";

export default function DisplayContador() {
    const contador = useStore(state => state.contador);

    return <h2>Contador: {contador}</h2>;
}
