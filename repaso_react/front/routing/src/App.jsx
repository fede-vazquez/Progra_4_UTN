import { Route, Switch } from "wouter";

import PlantDetail from "./pages/plant-detail";
import NavBar from "./components/nav-bar";
import Page404 from "./pages/page404";
import Plants from "./pages/plants";
import Home from "./pages/home";
import "./App.css";

function App() {
    return (
        <>
            <NavBar />

            <Switch>
                <Route path="/" component={Home} />
                <Route path="/plants" component={Plants} />

                {/* /plants/:id <- id es relativo */}
                <Route path="/plants/:id" component={PlantDetail} />
                <Route component={Page404} />
            </Switch>
        </>
    );
}

export default App;
