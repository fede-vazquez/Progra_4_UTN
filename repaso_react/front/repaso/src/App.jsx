import { useEffect, useState } from "react";
import "./App.css";

function App() {
    const [per, setPer] = useState({
        name: "",
        ki: "",
        description: "",
    }); // per = Personaje

    useEffect(() => {
        fetch("https://dragonball-api.com/api/characters/1")
            .then(res => res.json())
            .then(data => setPer(data));
    }, []);

    return (
        <>
            <h1>Nombre: {per.name}</h1>
            <span>Ki: {per.ki}</span>
            <p>Descripción: {per.description}</p>
        </>
    );
}

export default App;

// useEffect(() => {
//     console.log("Ejecución del efecto");
//     return () => {
//         console.log("Componente eliminado");
//     };
// }, []);

// Si estuviera el setCount dentro del efecto se haría un bucle infinito.
// const [count, setCount] = useState(0);
// useEffect(() => {
//      const font = document.getElementById("font");
//      font.style.fontSize = `${14 + count}px`;
// }, [count]);
