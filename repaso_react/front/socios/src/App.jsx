import { Route, Router } from "wouter";
import "./App.css";
import Header from "./components/header";
import Home from "./pages/home";
import Socios from "./pages/socios";
import Details from "./pages/details";

function App() {
    return (
        <>
            <Header />
            <Router>
                <Route path="/" component={Home} />
                <Route path="/socios" component={Socios} />
                <Route path="/socios/:id" component={Details} />
            </Router>
        </>
    );
}

export default App;

/*
- Página principal con bienvenida y un navbar

- Página de socios, muestra una lista de socios.
    Si el socio tiene estado = "ACT", la card se "pinta"
    de un color diferente al resto.
    (Solo mostrar datos relevantes de la card)

- Página de socio, mostrar toda la info
    y calcular el IMC.
*/
