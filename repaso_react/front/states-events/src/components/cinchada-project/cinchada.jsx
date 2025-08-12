import { useState } from "react";
import Equipo from "./equipo";

const equipoA = "red";
const equipoB = "green";
export default function Cinchada() {
    const [cuerdaEquipos, setCuerdaEquipos] = useState({
        [equipoA]: 5,
        [equipoB]: 5,
    });

    const handleTirar = colorSeleccionado => {
        const colores = Object.keys(cuerdaEquipos);

        const otroColor = colores.find(color => color != colorSeleccionado);

        setCuerdaEquipos(prev => ({
            [colorSeleccionado]: prev[colorSeleccionado] + 1,
            [otroColor]: prev[otroColor] - 1,
        }));
    };

    // const [cuerdaEquipos, setCuerdaEquipos] = useState({ red: 5, green: 5 });
    // const handleTirar = color => {
    //     if (color === "red") {
    //         setCuerdaEquipos(prev => ({
    //             red: prev.red + 1,
    //             green: prev.green - 1,
    //         }));
    //     } else {
    //         setCuerdaEquipos(prev => ({
    //             red: prev.red - 1,
    //             green: prev.green + 1,
    //         }));
    //     }
    // };

    return (
        <div style={{ display: "flex", alignItems: "center", gap: "20px" }}>
            <Equipo
                color={equipoA}
                distancia={cuerdaEquipos[equipoA]}
                onTirar={handleTirar}
            />
            <span>
                --------------------------------------------------------------
                <div>
                    Longitud: {cuerdaEquipos[equipoB] + cuerdaEquipos[equipoA]}m
                </div>
            </span>
            <Equipo
                color={equipoB}
                distancia={cuerdaEquipos[equipoB]}
                onTirar={handleTirar}
            />
        </div>
    );
}
