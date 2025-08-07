import { useParams } from "wouter";
import { getOnePlanetById } from "@/services/dragon-ball-api";
import { useEffect, useState } from "react";

export default function PlanetDetail() {
    const { id } = useParams();
    const [planet, setPlanet] = useState({});

    useEffect(() => {
        getOnePlanetById(id).then(data => setPlanet(data));
    }, [id]);

    return (
        <main>
            <section className="hero bg-base-200 min-h-screen">
                <div className="hero-content flex-col lg:flex-row">
                    <figure className="flex flex-col">
                        <img
                            src={planet.image}
                            alt={planet.name}
                            className="max-w-sm rounded-lg shadow-2xl"
                        />
                        <figcaption className="text-center">
                            Estado:{" "}
                            {planet.isDestroyed ? "Destruido" : "Normal"}
                        </figcaption>
                    </figure>
                    <div>
                        <h1 className="text-5xl font-bold">{planet.name}</h1>
                        <p className="py-6">{planet.description}</p>
                    </div>
                </div>
            </section>
        </main>
    );
}
