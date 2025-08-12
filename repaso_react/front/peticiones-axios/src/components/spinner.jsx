export default function Spinner({ type = "warning" }) {
    return (
        <span
            className={`loading loading-spinner text-${type} w-1/12 h-screen block mx-auto`}
        ></span>
    );
}
