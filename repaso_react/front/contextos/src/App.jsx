import BisAbuelo from "./components/bis-abuelo";
import CountProvider from "./context/count-provider";

function App() {
    return (
        <>
            <h1>Hola</h1>
            <CountProvider>
                <BisAbuelo />
            </CountProvider>
        </>
    );
}

export default App;
