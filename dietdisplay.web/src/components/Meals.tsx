import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import { Box, Collapse, Container, IconButton, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import React from 'react';
import { getDate } from '../helpers/dateHelper';
import { Meal, MealType } from './models/Meal';


export interface MealsProps {
    meals: Meal[];
}

function Row({ row, isExpandedByDefault }: { row: Meal, isExpandedByDefault: boolean }) {
  const [open, setOpen] = React.useState(isExpandedByDefault);

  return (
    <React.Fragment>
      <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell component="th" scope="row">
          {row.type}
        </TableCell>
        <TableCell component="th" scope="row">
          {row.preparation}
        </TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Table size="small" aria-label="ingredients">
                <TableHead>
                  <TableRow>
                    <TableCell>Co</TableCell>
                    <TableCell>Ile (g)</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.ingredients.map((ingredientsRow, i) => (
                    <TableRow key={i}>
                      <TableCell component="th" scope="row">
                        {ingredientsRow.name}
                      </TableCell>
                      <TableCell>{ingredientsRow.quantity}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </React.Fragment>
  );
}

function dividePeriodIntoParts(start: Date, end: Date, numberOfParts: number): Date[] {
  const diffInMillis = end.getTime() - start.getTime();
  const intervalInMillis = diffInMillis / numberOfParts;

  const result: Date[] = [];

  const todayMidnight = getDate(start);
  result.push(todayMidnight);

  for (let i = 0; i <= numberOfParts - 1; i++) {
    const newDate = new Date(start.getTime() + intervalInMillis * i);
    result.push(newDate);
  }

  const endOfDay = new Date(todayMidnight.getFullYear(), todayMidnight.getMonth(), todayMidnight.getDate(), 23, 59, 59, 999);
  result.push(endOfDay);

  return result;
}

function isBetween(date: Date, startDate: Date, endDate: Date) {
  return date >= startDate && date < endDate;
}

const expandedByDefaultMealType = (meals: Meal[]) => {
  const now = new Date();
  console.log("now", now);
  const firstMealTime = new Date(now);
  firstMealTime.setHours(10, 30, 0, 0);
  const lastMealTime = new Date(now);
  lastMealTime.setHours(18, 0, 0, 0);

  if (now < firstMealTime) 
    return meals[0].type;
  if (now > lastMealTime)
    return meals[meals.length - 1].type;

  const mealPeriods = dividePeriodIntoParts(firstMealTime, lastMealTime, meals.length - 1);
  const mealPeriodsWithTypes: { periodStart: Date, periodEnd: Date, mealType: MealType }[] = [];
  for (let i = 0; i < mealPeriods.length - 1; i++) {
    mealPeriodsWithTypes.push({
      periodStart: mealPeriods[i],
      periodEnd: mealPeriods[i + 1],
      mealType: meals[i].type
    });
  }
  const currentMealPeriod = mealPeriodsWithTypes.find((mealPeriodWithType) => isBetween(now, mealPeriodWithType.periodStart, mealPeriodWithType.periodEnd));
  return currentMealPeriod?.mealType ?? meals[0].type;
}

export const Meals = ({ meals }: MealsProps) => {
  if (meals.length === 0) {
    return (<Container data-testid='meals'>Brak posiłków</Container>)
  }

  const mealTypeExpandedbyDefault: MealType = expandedByDefaultMealType(meals);
  return (
      <Container data-testid='meals'>
          <TableContainer>
              <Table aria-label="collapsible table">
                  <TableHead>
                      <TableRow>
                          <TableCell />
                          <TableCell>Posiłek</TableCell>
                          <TableCell>Przygotowanie</TableCell>
                      </TableRow>
                  </TableHead>
                  <TableBody>
                    {
                      meals.map((meal) => (
                        <Row key={meal.type} row={meal} isExpandedByDefault={mealTypeExpandedbyDefault === meal.type}/>
                      ))
                    }
                  </TableBody>
              </Table> 
          </TableContainer>
      </Container>
  );
}