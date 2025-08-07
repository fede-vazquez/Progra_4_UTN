import { defaultDBSGet } from "./index.js";

export const getAllPlanets = async () => defaultDBSGet("/planets");

export const getOnePlanetById = async id => defaultDBSGet(`/planets/${id}`);
