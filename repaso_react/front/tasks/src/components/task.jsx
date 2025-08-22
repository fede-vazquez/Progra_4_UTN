export default function Task({ id, text, completed, onComplete, onDelete }) {
    return (
        <li key={id}>
            <span className={`${completed && "text-green-700"}`}>{text}</span>
            {!completed && (
                <input type="checkbox" id={id} onClick={onComplete} />
            )}
            <button onClick={onDelete}> 🗑</button>
        </li>
    );
}
