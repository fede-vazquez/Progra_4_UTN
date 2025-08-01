import { useParams } from "wouter";
import socios from "../socios.json";

export default function Details() {
    const param = useParams();

    const socio = socios.find(socio => socio.id === Number(param.id));

    const { nombre, apellido, estado, telefono, altura, plan, peso } = socio;

    return (
        <>
            <h1>
                {nombre} {apellido}
            </h1>
            <h2>Datos</h2>
            <ul>
                <li>Estado: {estado}</li>
                <li>Teléfono: {telefono}</li>
                <li>Altura: {altura}</li>
                <li>Plan: {plan}</li>
                <li>IMC: {(peso / (altura * altura)).toFixed(1)}</li>
            </ul>
        </>
    );
}
