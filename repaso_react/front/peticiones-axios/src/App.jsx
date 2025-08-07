import { Switch, Route } from "wouter";
import Home from "./pages/home";
import ListOfCharacters from "./pages/characters/list-of-characters";
import CharacterDetail from "./pages/characters/character-details";
import ListOfPlanets from "./pages/planets/list-of-planets";
import NavBar from "./components/nav-bar";
import PlanetDetail from "./pages/planets/planet-details";
import Page404 from "./pages/page404";

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

                <Route path={"/planets"}>
                    <ListOfPlanets />
                </Route>

                <Route path={"/planets/:id"}>
                    <PlanetDetail />
                </Route>

                <Route component={Page404} />
            </Switch>
        </>
    );
}

export default App;
