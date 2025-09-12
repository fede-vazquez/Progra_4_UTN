import Oro from "./oro";

export default function Pepe({ depositado, onMinar }) {
    return (
        <>
            <div>Soy pepe</div>
            <Oro depositado={depositado} minar={onMinar} />
        </>
    );
}
