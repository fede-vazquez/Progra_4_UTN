import Card from "../components/card";
import socios from "../socios.json";

export default function Socios() {
    return (
        <div>
            <h1>Socios:</h1>
            <ul className="flex flex-wrap justify-center gap-6">
                {socios &&
                    socios.map(socio => {
                        return (
                            <li key={socio.id}>
                                <Card socio={socio} />
                            </li>
                        );
                    })}
            </ul>
        </div>
    );
}
