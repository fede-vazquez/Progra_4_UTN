import { useState } from "react";
import Cursor from "./Cursor";

function App() {
    const [enabled, setEnabled] = useState(false);
    return (
        <main className="flex justify-center items-center h-screen w-full">
            <section>
                <button
                    onClick={() => {
                        setEnabled(true);
                    }}
                    type="button"
                    className="cursor-pointer focus:outline-none text-white bg-green-700 hover:bg-green-800 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-green-600 dark:hover:bg-green-700"
                >
                    Prender
                </button>
                <button
                    onClick={() => {
                        setEnabled(false);
                    }}
                    type="button"
                    className="cursor-pointer focus:outline-none text-white bg-red-700 hover:bg-red-800 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700"
                >
                    Apagar
                </button>
            </section>
            {enabled && <Cursor />}
        </main>
    );
}

export default App;

// A los valores que no tengamos, por ejemplo si queremos un width de 17px, podemos ponerlo entre corchetes.
// w-[17px]
// Funciona con casi todo
// FlowBite <- biblioteca de componentes de tailwind
