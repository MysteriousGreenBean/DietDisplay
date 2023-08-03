import { Alert, CircularProgress, Container } from '@mui/material';
import { useMemo } from 'react';
import { Meals } from './Meals/Meals';
import { CacheMethod, HttpMethod, useApi } from './hooks/useApi';
import { Meal } from './models/Meal';


export interface DietForProps {
    date: Date;
}

export const DietFor = ({ date }: DietForProps) => {
    const encodedDate = useMemo(() => encodeURIComponent(date.toDateString()), [date]);
    const { data: meals, loading, error} = useApi<Meal[]>(`meals?date=${encodedDate}`, HttpMethod.GET, CacheMethod.LocalStorage);

    if (loading) {
        return <Container><CircularProgress /><Container>Ładowanie posiłków...</Container></Container>
    }

    if (error) {
        return <Alert severity="error">Wystąpił bład podczas ładowania posiłków: {error.toString()}</Alert>;
    }

    return (
        <Container data-testid='dietFor'>
            <Meals meals={meals}/>
        </Container>
    );
}