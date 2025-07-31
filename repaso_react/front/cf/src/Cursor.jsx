import { useEffect, useState } from "react";

export default function Cursor() {
    const [border, setBorder] = useState("border-blue-600");
    useEffect(() => {
        setTimeout(() => {
            setBorder("border-green-700");
        }, 200);

        return () => {
            setBorder("border-red-700");
        };
    }, []);

    // Este useEffect va a ser para cuando se empiece a mover.
    // Tarea (windows.client // te da las coordenadas del cursor // hacerlo con style y no con className)

    useEffect(() => {
        // opción sin usar useState
        const handleMouseMove = e => {
            iconEl.style.transform = `translate(${
                e.clientX - iconEl.offsetWidth / 2
            }px, ${e.clientY - iconEl.offsetHeight / 2}px)`;
            // iconEl.style.top = `${e.clientY - iconEl.offsetHeight / 2}px`;
            // iconEl.style.left = `${e.clientX - iconEl.offsetWidth / 2}px`;
        };

        const iconEl = document.getElementById("icon");
        window.onmousemove = handleMouseMove;

        return () => {
            window.onmousemove = null;
        };
    }, []);

    return (
        <div
            id="icon"
            className={`${border} z-[-1] top-0 left-0 bg-gray-900 absolute w-20 h-20 border-2 rounded-full`}
        ></div>
    );
}
