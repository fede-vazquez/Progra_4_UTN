import axios from "axios";

export const instanceDBS = axios.create({
    baseURL: "https://dragonball-api.com/api",
    // Cada 1000ms intenta hacer una re-conexión
    timeout: 1000,
});
// Este export es para evitar tener que cambiar las URLs dependiendo de cual estemos utilizando
// Por ejemplo, en lugar de "./services/dragon-ball-api/characters.js" es "./services/dragon-ball-api"
// (no se agrega index.js porque se hace automático.)
export * from "./characters";

export * from "./planets";
