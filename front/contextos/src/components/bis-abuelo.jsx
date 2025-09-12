import { useContext } from "react";
import CountContext from "../context/count";
import Abuelo from "./abuelo";

export default function BisAbuelo() {
    const { handleIncrementar } = useContext(CountContext);

    return (
        <div className="border-2 border-red-500">
            <h1>Soy el BisAbuelo</h1>
            <button onClick={handleIncrementar}>Aumentar</button>
            <Abuelo />
        </div>
    );
}
