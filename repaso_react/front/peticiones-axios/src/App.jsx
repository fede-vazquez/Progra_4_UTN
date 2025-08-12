import { Switch, Route } from "wouter";
import NavBar from "./components/nav-bar";
import { Suspense, lazy } from "react";
import Spinner from "./components/spinner";

// El lazy load va a funcionar solo si el componente está exportado por default (manera simple)
// Es para que no carguen todos los componentes aunque no sea vean
const HomePage = lazy(() => import("./pages/home"));
const ListOfCharactersPage = lazy(() =>
    import("./pages/characters/list-of-characters")
);
const CharacterDetailPage = lazy(() =>
    import("./pages/characters/character-details")
);
const ListOfPlanetsPage = lazy(() => import("./pages/planets/list-of-planets"));
const PlanetDetailPage = lazy(() => import("./pages/planets/planet-details"));
const Page404Page = lazy(() => import("./pages/page404"));

function App() {
    return (
        <>
            <NavBar />

            <Suspense fallback={<Spinner />}>
                <Switch>
                    <Route path={"/"}>
                        <HomePage />
                    </Route>

                    <Route path={"/characters"}>
                        <ListOfCharactersPage />
                    </Route>

                    <Route path={"/characters/:id"}>
                        <CharacterDetailPage />
                    </Route>

                    <Route path={"/planets"}>
                        <ListOfPlanetsPage />
                    </Route>

                    <Route path={"/planets/:id"}>
                        <PlanetDetailPage />
                    </Route>

                    <Route component={Page404Page} />
                </Switch>
            </Suspense>
        </>
    );
}

export default App;
