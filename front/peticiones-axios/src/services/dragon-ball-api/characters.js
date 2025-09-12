import { defaultDBSGet } from "./index.js";

export const getAllCharacters = async () => defaultDBSGet("/characters");

export const getOneCharacterById = async id =>
    defaultDBSGet(`/characters/${id}`);

export const getOneCharacterByName = async name =>
    defaultDBSGet(`/characters?name=${name}`);
