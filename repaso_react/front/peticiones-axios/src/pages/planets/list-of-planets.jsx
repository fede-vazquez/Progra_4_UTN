import { useEffect, useState } from "react";
import { getAllPlanets } from "@/services/dragon-ball-api";
import CardPlanet from "@/components/planets/card-planet";

export default function ListOfPlanets() {
    const [planets, setPlanets] = useState([]);
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
                    // {...plt} -> usa el express operator para pasar todos los parámetros al componente
                    <CardPlanet key={plt.id} {...plt} />
                )
            )}
        </main>
    );
}
