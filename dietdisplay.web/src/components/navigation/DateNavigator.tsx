import { AppBar, Box, Button, Container, Toolbar, Typography } from "@mui/material";
import { useState } from "react";
import { addDays } from "../../helpers/dateHelper";

export interface DateNavigatorProps {
    currentDate: Date;
    onDateChange?: (date: Date) => void;
}

export const DateNavigator = ({currentDate, onDateChange} : DateNavigatorProps) => {
    const [ date, setDate ] = useState(currentDate);

    const updateDate = (newDate: Date) => {
        onDateChange?.(newDate);
        setDate(newDate);
    };

    const nextDate = addDays(1, date);
    const nextWeekDate = addDays(30);

    return (
        <Container>
            <Box sx={{ width: '100%', top: 0, position: 'sticky'}}>
                <AppBar>
                    <Toolbar>
                        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                            {date.toLocaleDateString()}
                        </Typography>
                        <Button 
                            color="inherit" 
                            variant="outlined" 
                            onClick={() => updateDate(nextDate)}
                            disabled={nextDate > nextWeekDate}>
                                {`${nextDate.toLocaleDateString()} >`}
                            </Button>
                    </Toolbar>
                </AppBar>
            </Box>
        </Container>
    );
};
