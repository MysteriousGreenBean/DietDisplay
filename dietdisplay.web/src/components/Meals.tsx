import React from 'react';
import { Meal, MealType } from './models/Meal';
import { Box, Collapse, Container, IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';


export interface MealsProps {
    meals: Meal[];
}

function Row(props: { row: Meal}) {
  const { row } = props;
  const [open, setOpen] = React.useState(row.type === MealType.Breakfast);

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


export const Meals = ({ meals }: MealsProps) => {
    return (
        <Container>
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
                          <Row key={meal.type} row={meal} />
                        ))
                      }
                    </TableBody>
                </Table> 
            </TableContainer>
        </Container>
    );
}