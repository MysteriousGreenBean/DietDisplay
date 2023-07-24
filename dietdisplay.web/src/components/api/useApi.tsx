import { useMemo, useState } from "react";
import { getDate } from "../../helpers/dateHelper";

const url = "/api"; 

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

    useMemo(() => {
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        };

        setLoading(true);
        const callTarget = `${url}/${endpoint}`;
        fetch(callTarget, requestOptions)
            .then(response => response.json())
            .then((data) => {
                console.debug(`get ${callTarget}`, data);
                const parsedData = JSON.parse(JSON.stringify(data), (_, value) => {
                    if (typeof value === 'string' && /\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{7}Z/.test(value)) {
                      return getDate(new Date(value));
                    }
                    return value;
                  });
                setData(parsedData as TData);
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