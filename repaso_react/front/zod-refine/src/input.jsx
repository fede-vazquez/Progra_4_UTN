import { useId } from "react";

export default function Input({ type, title, name, register, error }) {
    // Delegamos la responsabilidad del id a React.
    const id = useId();

    return (
        <div className="control">
            <label htmlFor={id}>{title} </label>

            <input type={type} id={id} {...register(name)} />

            {error && <span className="error">{error.message}</span>}
        </div>
    );
}
