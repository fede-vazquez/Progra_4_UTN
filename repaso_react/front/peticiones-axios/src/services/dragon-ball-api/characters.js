import { HttpStatusCode } from "axios";
import { instanceDBS } from "./index.js";

const defaultGet = async url => {
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

export const getAllCharacters = async () => defaultGet("/characters");

export const getOneCharacterById = async id => defaultGet(`/characters/${id}`);

export const getOneCharacterByName = async name =>
    defaultGet(`/characters?name=${name}`);
