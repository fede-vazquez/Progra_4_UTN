import Hijo from "./hijo";

export default function Padre() {
    return (
        <div className="border-2 border-green-500">
            <h3>Soy el padre</h3>
            <Hijo />
        </div>
    );
}
