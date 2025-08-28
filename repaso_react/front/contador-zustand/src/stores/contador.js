import { create } from "zustand";

export const useStore = create((set, get) => ({
    contador: 0,
    aumentarContador: () => set(state => ({ contador: state.contador + 1 })),
    disminuirContador: () => set(state => ({ contador: state.contador - 1 })),
    resetearContador: () => set(() => ({ contador: 0 })),

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
