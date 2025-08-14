import Padre from "./padre";

export default function Abuelo() {
    return (
        <div className="border-2 border-blue-600">
            <h2>Soy el abuelo</h2>
            <Padre />
        </div>
    );
}
