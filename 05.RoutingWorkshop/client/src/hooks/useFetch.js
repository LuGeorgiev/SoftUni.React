import { useState, useEffect } from 'react';

const useFetch = (url, initValue) => {
    const [state, setState] = useState(initValue);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        
        setIsLoading(false)

        fetch(url)
        .then(res => res.json())
        .then(result => {
            setState(result);
            setIsLoading(true);
        });
    },[url]);

    return [ 
        state,
        isLoading
    ];
}

export default useFetch;