import { ThemeProvider, createTheme } from '@mui/material';
import './App.css';
import { DietFor } from './components/DietFor';

function App() {
  const theme = createTheme({
    palette: {
      mode: 'dark',
    },
  });

  return (
    <div className="App">  
      <ThemeProvider theme={theme}>
        <DietFor date={new Date()} />
      </ThemeProvider>
    </div>
  );
}

export default App;


