import { useEffect, useState } from "react";
import CardCharacter from "../../components/characters/card-character";
import { getAllCharacters } from "../../services/dragon-ball-api";

// La lógica de la petición de personajes podría estar directamente acá, pero eso no permitiría hacer filtros de forma más dinámica.

export default function ListOfCharacters() {
    const [chars, setChars] = useState([]); // chars -> characters
    useEffect(() => {
        getAllCharacters().then(data => {
            if (data?.items) setChars(data?.items);
        });
    }, []);
    return (
        <main className="flex flex-wrap gap-10 justify-center">
            {chars.map(ch => (
                // {...ch} -> usa el express operator para pasar todos los parámetros al componente
                <CardCharacter key={ch.id} {...ch} />
            ))}
        </main>
    );
}
