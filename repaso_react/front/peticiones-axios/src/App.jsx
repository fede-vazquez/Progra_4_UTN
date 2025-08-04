import { useEffect } from "react";
import { getOneCharacterById } from "./services/dragon-ball-api";

function App() {
    useEffect(() => {
        getOneCharacterById(2).then(data => console.log(data));
    }, []);

    return (
        <>
            <h1>Hola Mundo</h1>
        </>
    );
}

export default App;

// ver patron repository
