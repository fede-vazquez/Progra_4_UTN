import { useEffect, useState } from "react";
import { createPancho, getAllPanchos } from "./services/panchos";

function App() {
    const [panchos, setPanchos] = useState([]);

    useEffect(() => {
        getAllPanchos().then(setPanchos);
    }, []);

    const handleSubmit = e => {
        e.preventDefault();
        const form = e.target;

        const data = new FormData(form);

        const pancho = Object.fromEntries(data);
        const arrAderezos = pancho.aderezos.split(",");
        pancho.isVegano = Boolean(pancho.isVegano);
        pancho.aderezos = arrAderezos;
        console.log(pancho);

        createPancho(pancho).then(data => {
            // delete data.precio;
            // delete data.isVegano;
            // delete data.aderezo;
            setPanchos(prev => [...prev, data]);
            form.reset();
        });
    };

    return (
        <>
            <h1>Panchos</h1>

            <ul>
                {panchos.map(p => (
                    <li key={p.id}>
                        {p.id} - {p.nombre}
                    </li>
                ))}
            </ul>

            <form onSubmit={handleSubmit}>
                <label>
                    Nombre:
                    <br />
                    <input type="text" name="nombre" />
                </label>
                <br />

                <label>
                    Precio:
                    <br />
                    <input type="number" name="precio" />
                </label>
                <br />
                <label>
                    Es vegano:
                    <input type="checkbox" name="isVegano" />
                </label>
                <br />
                <label>
                    Aderezos (separados por coma):
                    <br />
                    <textarea name="aderezos"></textarea>
                </label>
                <br />
                <button type="submit">Enviar</button>
            </form>
        </>
    );
}

export default App;
