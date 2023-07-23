import { ThemeProvider, createTheme } from '@mui/material';
import { useState } from 'react';
import './App.css';
import { DietFor } from './components/DietFor';
import { DateNavigator } from './components/navigation/DateNavigator';
import { getCurrentDate } from './helpers/dateHelper';

function App() {
  const [ date, setDate ] = useState(getCurrentDate()); 
  
  const theme = createTheme({
    palette: {
      mode: 'dark',
    },
  });

  return (
    <div className="App">  
      <ThemeProvider theme={theme}>
        <DateNavigator currentDate={date} onDateChange={(newDate) => setDate(newDate)} />
        <DietFor date={date} />
      </ThemeProvider>
    </div>
  );
}

export default App;


