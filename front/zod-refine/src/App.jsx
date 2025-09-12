import { useForm } from "react-hook-form";
import Input from "./input";
import { userValidation } from "./validation/user-validation";
import { zodResolver } from "@hookform/resolvers/zod";

function App() {
    const {
        handleSubmit,
        register,
        formState: { errors },
    } = useForm({ resolver: zodResolver(userValidation) });

    const onSubmit = data => console.log(data);

    return (
        <>
            <h1>Hola mundo</h1>

            <form onSubmit={handleSubmit(onSubmit)}>
                <Input
                    type={"text"}
                    name={"username"}
                    title={"Nombre: "}
                    register={register}
                    error={errors?.username}
                />

                <Input
                    type={"text"}
                    name={"email"}
                    title={"Email: "}
                    register={register}
                    error={errors?.email}
                />

                <Input
                    type={"password"}
                    name={"password"}
                    title={"Contraseña: "}
                    register={register}
                    error={errors?.password}
                />

                <Input
                    type={"password"}
                    name={"confirmPassword"}
                    title={"Confirmar contraseña: "}
                    register={register}
                    error={errors?.confirmPassword}
                />

                <button>Aceptar</button>
            </form>
        </>
    );
}

export default App;

// Agregar un checkbox que tenga que estar seleccionado si o si.
