import { Link, useParams } from "wouter";
import { getOnePlanetById } from "@/services/dragon-ball-api";
import Spinner from "@/components/spinner";
import { useReq } from "@/hooks/use-req";

export default function PlanetDetail() {
    const { id } = useParams();
    const { data: planet, isLoading } = useReq({ promise: () => getOnePlanetById(id) })


    if (isLoading) return <Spinner type="primary" />

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

            <br />

            <section className="w-3/4 mx-auto flex flex-col gap-10">
                <h2 className="text-3xl">Personajes del planeta: </h2>
                {planet?.characters?.length > 0 ? (
                    planet?.characters?.map(char => (
                        <article key={char.id} className="hero bg-base-200">
                            <div className="hero-content flex-col lg:flex-row-reverse">
                                <img
                                    src={char.image}
                                    className="max-w-sm rounded-lg shadow-2xl max-h-52"
                                />
                                <div>
                                    <h3 className="text-xl font-bold">
                                        {char.name}
                                    </h3>
                                    <p className="py-6 max-h-60 overflow-y-scroll">
                                        {char.description}
                                    </p>
                                    <Link
                                        href={`/characters/${char.id}`}
                                        className="btn btn-primary"
                                    >
                                        More info
                                    </Link>
                                </div>
                            </div>
                        </article>
                    ))
                ) : (
                    <p>No se encontraron personajes en este planeta</p>
                )}
            </section>
        </main>
    );
}
