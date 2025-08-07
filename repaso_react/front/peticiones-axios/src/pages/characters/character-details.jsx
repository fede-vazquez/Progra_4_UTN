import { useParams } from "wouter";
import { getOneCharacterById } from "@/services/dragon-ball-api";
import { useEffect, useState } from "react";

export default function CharacterDetail() {
    const { id } = useParams();
    const [char, setChar] = useState({});

    useEffect(() => {
        getOneCharacterById(id).then(data => setChar(data));
    }, [id]);

    return (
        <main>
            <section className="hero bg-base-200 min-h-screen">
                <div className="hero-content flex-col lg:flex-row">
                    <img
                        src={char.image}
                        className="max-w-sm rounded-lg shadow-2xl"
                    />
                    <div>
                        <h1 className="text-5xl font-bold">{char.name}</h1>
                        <p className="py-6">{char.description}</p>
                    </div>
                </div>
            </section>
        </main>
    );
}
