import { useEffect, useState } from "react";

const url = "https://localhost:7281/api"; 

export interface APIResponse<TData> {
    data: TData;
    error: any;
    loading: boolean;
}

export enum HttpMethod {
    GET = "GET",
}

export function useApi<TData>(endpoint: string, method: HttpMethod): APIResponse<TData> {
    switch (method) {
        case HttpMethod.GET:
            return useGet(endpoint);
        default:
            throw new Error(`Unsupported method ${method}`);
    }
}

export function useGet<TData>(endpoint: string): APIResponse<TData> {
    const [data, setData] = useState<TData | undefined>(undefined);
    const [error, setError] = useState<any>(undefined);
    const [loading, setLoading] = useState<boolean>(true);

    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
    };

    useEffect (() => {
        setLoading(true);
        const callTarget = `${url}/${endpoint}`;
        fetch(callTarget, requestOptions)
            .then(response => response.json())
            .then((data) => {
                console.debug(`get ${callTarget}`, data);
                setData(data as TData);
                setLoading(false);
            }).catch((error) => {
                console.error(`error while calling get ${callTarget}`, error);
                setError(error);
                setLoading(false);
            });
    }, [endpoint]);

    return {
        data: data as TData,
        error: error,
        loading: loading,
    }
}