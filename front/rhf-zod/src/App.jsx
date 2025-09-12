import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";

const userValidation = z.object({
    nombre: z
        .string()
        .nonempty("Este campo es requerido")
        .max(30, "No podes usar mas de 30 caracteres"),
    email: z
        .email("El formato es invalido")
        .nonempty("Este campo es requerido"),
});

function App() {
    const {
        handleSubmit,
        register,
        formState: { errors },
    } = useForm({ resolver: zodResolver(userValidation) });

    const onSubmit = data => console.log(data);

    return (
        <>
            <h1>React-Hook-Form + ZOD</h1>

            <form onSubmit={handleSubmit(onSubmit)}>
                <div className="control">
                    <label htmlFor="nombre">Nombre: </label>
                    <input type="text" id="nombre" {...register("nombre")} />
                    {errors?.nombre && (
                        <span className="error">{errors.nombre.message}</span>
                    )}
                </div>
                <div className="control">
                    <label htmlFor="email">Email: </label>
                    <input type="text" id="email" {...register("email")} />
                    {errors?.email && (
                        <span className="error">{errors.email.message}</span>
                    )}
                </div>
                <button>Enviar</button>
            </form>
        </>
    );
}

export default App;
