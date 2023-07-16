import { render, screen } from '@testing-library/react';
import App from './App';

test('renders meals', () => {
  render(<App />);
  const mealsComponent = screen.getByTestId('meals');
  expect(mealsComponent).toBeInTheDocument();
});
