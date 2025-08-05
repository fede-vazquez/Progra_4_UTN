import { Link } from "wouter";

export default function CardCharacter({ id, image, name, ki, description }) {
    return (
        <section className="card bg-base-100 w-96 shadow-sm border-2 border-transparent hover:border-white transition">
            <figure className="flex flex-col">
                <img src={image} alt={name} className="h-72" />
                <figcaption>Ki: {ki}</figcaption>
            </figure>
            <div className="card-body">
                <h2 className="card-title">{name}</h2>
                <p className="h-20 overflow-y-scroll">{description}</p>
                <div className="card-actions justify-center">
                    <Link
                        href={`/characters/${id}`}
                        className="btn btn-primary"
                    >
                        Show more
                    </Link>
                </div>
            </div>
        </section>
    );
}
