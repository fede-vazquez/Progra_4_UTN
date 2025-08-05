import { Switch, Route } from "wouter";
import Home from "./pages/home";
import ListOfCharacters from "./pages/characters/list-of-characters";
import CharacterDetail from "./pages/characters/character-details";
import NavBar from "./components/nav-bar";

function App() {
    return (
        <>
            <NavBar />

            <Switch>
                <Route path={"/"}>
                    <Home />
                </Route>

                <Route path={"/characters"}>
                    <ListOfCharacters />
                </Route>

                <Route path={"/characters/:id"}>
                    <CharacterDetail />
                </Route>
            </Switch>
        </>
    );
}

export default App;

// Hacer lo que hicimos para personajes pero para planetas.
// Hacer componente de error.
// Agregar funcionalidad para que busque el personaje y agregue la info en el CharacterDetails.
