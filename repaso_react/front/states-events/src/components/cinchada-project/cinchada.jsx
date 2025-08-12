import { useState } from "react";
import Equipo from "./equipo";

export default function Cinchada() {
    const [cuerdaEquipos, setCuerdaEquipos] = useState({ red: 5, green: 5 });

    const handleTirar = color => {
        if (color === "red") {
            setCuerdaEquipos(prev => ({
                red: prev.red + 1,
                green: prev.green - 1,
            }));
        } else {
            setCuerdaEquipos(prev => ({
                red: prev.red - 1,
                green: prev.green + 1,
            }));
        }
    };

    return (
        <div style={{ display: "flex", alignItems: "center", gap: "20px" }}>
            <Equipo
                color={"red"}
                distancia={cuerdaEquipos.red}
                onTirar={handleTirar}
            />
            <span>
                --------------------------------------------------------------
                <div>Longitud: {cuerdaEquipos.green + cuerdaEquipos.red}m</div>
            </span>
            <Equipo
                color={"green"}
                distancia={cuerdaEquipos.green}
                onTirar={handleTirar}
            />
        </div>
    );
}

// Simplificar el código de la función tirar
