import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";
import tailwindcss from "@tailwindcss/vite";
import path from "path";

// https://vite.dev/config/
export default defineConfig({
    plugins: [react(), tailwindcss()],
    resolve: {
        // Con los alias podemos conseguir rutas de forma más simple.
        // El jsconfig.json sirve para que vscode me de el auto-completado
        alias: {
            "@": path.resolve(__dirname, "./src"),
        },
    },
});
