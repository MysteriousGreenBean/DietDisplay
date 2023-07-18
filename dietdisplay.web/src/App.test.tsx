import { render, screen, waitFor } from '@testing-library/react';
import App from './App';
import { MealsMock } from './fixture/MealMocks';


describe('App', () => {
  beforeEach(() => {
    jest.spyOn(global, "fetch",).mockImplementation( 
      jest.fn(
        () => Promise.resolve({ json: () => Promise.resolve(MealsMock), 
      }), 
    ) as jest.Mock ) 
    
  });

  it('renders dietFor', async () => {
    render(<App />);
    await waitFor(() => {
      const mealsComponent = screen.getByTestId('dietFor');
      expect(mealsComponent).toBeInTheDocument();
    });
  });
});

