const TOTAL_ORO = 50;

export default function Oro({ depositado, minar }) {
    return (
        <>
            <div>Mena de oro: {TOTAL_ORO - depositado} unidades</div>
            <button onClick={() => minar(3)}>Minar oro</button>
        </>
    );
}
