import * as z from "zod";

export const userValidation = z
    .object({
        username: z
            .string()
            .nonempty("Este campo no debe estar vacío")
            .min(5, "Este campo debe tener como mínimo 5 caracteres"),
        email: z.email("Formato de mail no válido").nonoptional(),
        password: z
            .string()
            .regex(
                /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#+-]).{8,}$/,
                "El formato es incorrecto"
            ),
        confirmPassword: z
            .string()
            .regex(
                /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#+-]).{8,}$/,
                "El formato es incorrecto"
            ),
    })
    .refine(data => data.password === data.confirmPassword, {
        message: "Las contraseñas no coinciden",
        path: ["confirmPassword"],
    });
