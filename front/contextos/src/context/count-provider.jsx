import { useState } from "react";
import CountContext from "./count";

export default function CountProvider({ children }) {
    const [count, setCount] = useState(0);

    const handleIncrementar = () => setCount(prev => prev + 1);

    return (
        // En el valor puede ir cualquier cosa
        <CountContext.Provider value={{ count, handleIncrementar }}>
            {children}
        </CountContext.Provider>
    );
}
