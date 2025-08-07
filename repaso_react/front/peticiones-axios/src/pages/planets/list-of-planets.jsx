import { useEffect, useState } from "react";
import { getAllPlanets } from "@/services/dragon-ball-api";
import CardPlanet from "@/components/planets/card-planet";

// La lógica de la petición de personajes podría estar directamente acá, pero eso no permitiría hacer filtros de forma más dinámica.

export default function ListOfPlanets() {
    const [planets, setPlanets] = useState([]); // planets -> characters
    useEffect(() => {
        getAllPlanets().then(data => {
            if (data?.items) setPlanets(data?.items);
        });
    }, []);
    return (
        <main className="flex flex-wrap gap-10 justify-center">
            {planets.map(
                (
                    plt // plt -> planet
                ) => (
                    // {...ch} -> usa el express operator para pasar todos los parámetros al componente
                    <CardPlanet key={plt.id} {...plt} />
                )
            )}
        </main>
    );
}
