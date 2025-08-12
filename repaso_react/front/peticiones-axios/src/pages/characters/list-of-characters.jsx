import CardCharacter from "@/components/characters/card-character";
import { getAllCharacters } from "@/services/dragon-ball-api";
import Spinner from "@/components/spinner";
import { useReq } from "@/hooks/use-req";
import { useLocation } from "wouter";

export default function ListOfCharacters() {
    const { data, isLoading } = useReq({ promise: getAllCharacters })
    const [location, navigate] = useLocation()

    const handleClick = () => navigate("/")

    if (isLoading) return <Spinner type="primary" />
    return (
        <main className="flex flex-wrap gap-10 justify-center">
            <button onClick={handleClick}>Home</button>
            {data?.items?.map(ch => (
                // {...ch} -> usa el express operator para pasar todos los parámetros al componente
                <CardCharacter key={ch.id} {...ch} />
            ))}
        </main>
    );
}
