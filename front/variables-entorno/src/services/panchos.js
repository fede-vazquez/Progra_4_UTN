const { VITE_API_URL } = import.meta.env;

export const getAllPanchos = async () => {
    const res = await fetch(`${VITE_API_URL}/panchos`);
    const data = await res.json();

    return data;
};

export const createPancho = async pancho => {
    const res = await fetch(`${VITE_API_URL}/panchos`, {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(pancho),
    });
    const data = await res.json();

    return data;
};
