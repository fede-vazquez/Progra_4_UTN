import { Link } from "wouter";

export default function Card({ socio }) {
    const { id, nombre, apellido, estado, telefono, altura } = socio;

    return (
        <Link
            href={`/socios/${id}`}
            className={`block max-w-sm p-6 bg-white border border-gray-200 rounded-lg shadow-sm hover:bg-gray-100  ${
                estado == "ACT"
                    ? "dark:bg-green-500 dark:border-green-900 dark:hover:bg-green-700"
                    : "dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
            }`}
        >
            <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                {nombre} {apellido}
            </h5>
            <ul>
                <li>Teléfono: {telefono}</li>
                <li>Altura: {altura}</li>
            </ul>
            <p className="font-normal text-gray-700 dark:text-gray-400"></p>
        </Link>
    );
}
