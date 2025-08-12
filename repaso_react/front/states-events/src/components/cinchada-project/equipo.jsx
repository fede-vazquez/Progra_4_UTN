export default function Equipo({ color, distancia, onTirar }) {
    return (
        <div>
            <div>
                Equipo: <span style={{ color }}>{color}</span>
            </div>
            <div>Distancia: {distancia} metros</div>
            <button onClick={() => onTirar(color)}>Tirar 1 m</button>
        </div>
    );
}
