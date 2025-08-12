import { useState } from "react";
import Pepe from "./pepe";

export default function Deposito() {
    const [unidades, setUnidades] = useState(0);

    const depositar = cant => setUnidades(unidades + cant);

    return (
        <>
            <div>Total oro depositado: {unidades} unidades</div>
            <Pepe depositado={unidades} onMinar={depositar} />
        </>
    );
}
