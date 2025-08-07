import { Link } from "wouter";

export default function CardPlanet({ id, image, name, description }) {
    return (
        <section className="card bg-base-100 image-full w-96 shadow-sm">
            <figure>
                <img
                    className="aspect-video"
                    src={image}
                    alt={`imagen de planeta ${name}`}
                />
            </figure>
            <div className="card-body">
                <h2 className="card-title">{name}</h2>
                <p className="h-36 overflow-y-scroll">{description}</p>
                <div className="card-actions justify-end">
                    <Link href={`/planets/${id}`} className="btn btn-primary">
                        More info
                    </Link>
                </div>
            </div>
        </section>
    );
}
