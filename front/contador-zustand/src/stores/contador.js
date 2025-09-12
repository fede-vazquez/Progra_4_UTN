import { create } from "zustand";
import { persist } from "zustand/middleware";

const handle = (set, get) => ({
    contador: 0,

    aumentarContador: () => set(state => ({ contador: state.contador + 1 })),
    disminuirContador: () => set(state => ({ contador: state.contador - 1 })),
    resetearContador: () => set({ contador: 0 }),
});

export const useCountStore = create(persist(handle, { name: "counter" }));

export const useUserStore = create(set => ({
    usuarios: [],

    cargarUsuarios: async () => {
        try {
            const respuesta = await fetch(
                "https://jsonplaceholder.typicode.com/users"
            );
            const datos = await respuesta.json();
            console.log(datos);
            set({ usuarios: datos });
        } catch (error) {
            console.error(
                `No se pudieron cargar los usuarios - error: ${error}`
            );
        }
    },
}));
