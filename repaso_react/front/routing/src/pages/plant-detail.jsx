import { Link, useParams } from "wouter";
import { plants } from "../data";
import Page404 from "./page404";

export default function PlantDetail() {
    const { id } = useParams();

    const plant = plants.find(pl => {
        // Es importante el ===, para comparar tipos.
        return pl.id === Number(id);
    });

    if (plant == null) {
        return <Page404 />;
    }

    return (
        <div>
            <h1>Id: {plant.id}</h1>
            <p>Nombre: {plant.name}</p>
            <Link href="/plants">Go Back</Link>
        </div>
    );
}
