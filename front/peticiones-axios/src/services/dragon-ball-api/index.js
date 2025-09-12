import axios, { HttpStatusCode } from "axios";

export const instanceDBS = axios.create({
    baseURL: "https://dragonball-api.com/api",
    // Cada 1000ms intenta hacer una re-conexión
    timeout: 1000,
});

export const defaultDBSGet = async url => {
    const { data, status } = await instanceDBS.get(url);
    // Esto es importante ya que cuando vayamos al backend vamos a tener distintos mensajes de error
    switch (status) {
        case HttpStatusCode.Ok: {
            return data;
        }
        default:
            throw new Error("Error desconocido");
    }
};

// Este export es para evitar tener que cambiar las URLs dependiendo de cual estemos utilizando
// Por ejemplo, en lugar de "./services/dragon-ball-api/characters.js" es "./services/dragon-ball-api"
// (no se agrega index.js porque se hace automático.)
export * from "./characters";

export * from "./planets";
