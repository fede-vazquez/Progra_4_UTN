import { Link, useParams } from "wouter";
import { getOneCharacterById } from "@/services/dragon-ball-api";
import Spinner from "@/components/spinner";
import { useReq } from "@/hooks/use-req";

export default function CharacterDetail() {
    const { id } = useParams();

    const { data: char, isLoading } = useReq({ promise: () => getOneCharacterById(id) })


    if (isLoading) return <Spinner type="primary" />

    return (
        <main>
            <section className="hero bg-base-200 w-3/4 mx-auto">
                <div className="hero-content flex-col lg:flex-row">
                    <img
                        src={char.image}
                        alt={`imagen de ${char.name}`}
                        className="max-w-sm rounded-lg shadow-2xl h-80"
                    />
                    <div>
                        <h1 className="text-5xl font-bold">{char.name}</h1>
                        <p className="py-6 max-h-60 overflow-y-scroll">
                            {char.description}
                        </p>
                    </div>
                </div>
            </section>

            <br />

            <section className="hero bg-base-200 w-3/4 mx-auto">
                <div className="hero bg-base-200">
                    <div className="hero-content flex-col lg:flex-row-reverse">
                        <img
                            src={char?.originPlanet?.image}
                            className="max-w-sm rounded-lg shadow-2xl max-h-52"
                        />
                        <div>
                            <h3 className="text-xl font-bold">
                                Planeta de origen: {char?.originPlanet?.name}
                            </h3>
                            <p className="py-6 max-h-60 overflow-y-scroll">
                                {char?.originPlanet?.description}
                            </p>
                            <Link
                                href={`/planets/${char?.originPlanet?.id}`}
                                className="btn btn-primary"
                            >
                                More info
                            </Link>
                        </div>
                    </div>
                </div>
            </section>
        </main>
    );
}
