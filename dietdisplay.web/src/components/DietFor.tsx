import { Alert, CircularProgress, Container } from '@mui/material';
import { useMemo } from 'react';
import { Meals } from './Meals';
import { HttpMethod, useApi } from './api/useApi';
import { Meal } from './models/Meal';


export interface DietForProps {
    date: Date;
}

export const DietFor = ({ date }: DietForProps) => {
    const encodedDate = useMemo(() => encodeURIComponent(date.toISOString()), [date]);
    const { data: meals, loading, error} = useApi<Meal[]>(`meals/${encodedDate}`, HttpMethod.GET);

    if (loading) {
        return <Container><CircularProgress /><Container>Ładowanie posiłków...</Container></Container>
    }

    if (error) {
        return <Alert severity="error">Wystąpił bład podczas ładowania posiłków: {error.toString()}</Alert>;
    }

    return (
        <Container data-testid='dietFor'>
            <h1>Dieta na dzień {date.toLocaleDateString()}</h1>
            <Meals meals={meals}/>
        </Container>
    );
}