import { useEffect, useState } from "react";

// Los custom hooks siempre se exportan nombrados
export const useReq = ({ promise }) => {
    const [isLoading, setIsLoading] = useState(true);
    const [data, setData] = useState(null);

    useEffect(() => {
        promise()
            .then(data => {
                if (data) setData(data);
            })
            .finally(() => setIsLoading(false));
    }, []);

    return { data, isLoading };
};
