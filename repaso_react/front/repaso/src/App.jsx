import { useEffect, useState } from "react";
import "./App.css";

function App() {
    const [per, setPer] = useState({
        name: "",
        ki: "",
        description: "",
        gender: "",
    }); // per = Personaje

    const [id, setId] = useState(1);

    useEffect(() => {
        fetch(`https://dragonball-api.com/api/characters/${id}`)
            .then(res => res.json())
            .then(data => setPer(data));
    }, [id]);

    const handleSubmit = e => {
        e.preventDefault();

        const data = new FormData(e.target);
        const idToFind = data.get("idToFind");

        if (idToFind >= 1) {
            setId(idToFind);
        }
    };

    return (
        <>
            <h1>Id: {id}</h1>
            <h2>Nombre: {per.name}</h2>
            <span>Ki: {per.ki}</span>
            <p>Descripción: {per.description}</p>
            <p>Genero: {per.gender}</p>

            <form onSubmit={handleSubmit}>
                <label htmlFor="idToFind">
                    Id:
                    <input type="number" name="idToFind" />
                </label>
                <button type="submit">Buscar</button>
            </form>
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

// poner un input type number en lugar del botón.
