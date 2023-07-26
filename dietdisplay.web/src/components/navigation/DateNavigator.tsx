import { AppBar, Box, Button, Container, Toolbar, Typography, useMediaQuery } from "@mui/material";
import { useState } from "react";
import { addDays } from "../../helpers/dateHelper";
import { HttpMethod, useApi } from "../api/useApi";
import { MealRange } from "../models/MealRange";

export interface DateNavigatorProps {
    currentDate: Date;
    onDateChange?: (date: Date) => void;
}

export const DateNavigator = ({currentDate, onDateChange} : DateNavigatorProps) => {
    const [ date, setDate ] = useState(currentDate);
    const isSmallScreen = useMediaQuery((theme: any) => theme.breakpoints.down('sm'));

    const { data: mealRange, loading, error } = useApi<MealRange>('mealRange', HttpMethod.GET);

    const updateDate = (newDate: Date) => {
        onDateChange?.(newDate);
        setDate(newDate);
    };

    const nextDate = addDays(1, date);
    const previousDate = addDays(-1, date);
    
    const nextbuttonText = isSmallScreen ? '>' : `${nextDate.toLocaleDateString()} >`;
    const previousButtonText = isSmallScreen ? '<' : `< ${previousDate.toLocaleDateString()}`;

    const isNextButtonDisabled = () => {
        if (loading || error) 
            return true;
        return nextDate > mealRange.newestDate;
    };

    const isPreviousButtonDisabled = () => {
        if (loading || error) 
            return true;
        return previousDate < mealRange.oldestDate;
    };

    return (
        <Container>
            <Box sx={{ width: '100%', top: 0, position: 'sticky', zIndex: 9999}}>
                <AppBar>
                    <Toolbar>
                        <Button 
                            color="inherit" 
                            variant="outlined" 
                            onClick={() => updateDate(previousDate)}
                            disabled={isPreviousButtonDisabled()}>
                                {previousButtonText}
                        </Button>
                        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                            {date.toLocaleDateString()}
                        </Typography>
                        <Button 
                            color="inherit" 
                            variant="outlined" 
                            onClick={() => updateDate(nextDate)}
                            disabled={isNextButtonDisabled()}>
                                {nextbuttonText}
                        </Button>
                    </Toolbar>
                </AppBar>
            </Box>
        </Container>
    );
};
