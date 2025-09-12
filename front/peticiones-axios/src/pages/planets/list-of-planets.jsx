import { getAllPlanets } from "@/services/dragon-ball-api";
import CardPlanet from "@/components/planets/card-planet";
import Spinner from "@/components/spinner";
import { useReq } from "@/hooks/use-req";

export default function ListOfPlanets() {
    const { data, isLoading } = useReq({ promise: getAllPlanets })

    if (isLoading) return <Spinner type="primary" />
    return (
        <main className="flex flex-wrap gap-10 justify-center">
            {data?.items?.map(
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
