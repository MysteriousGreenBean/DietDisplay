// test DietFor component

import { render, screen } from '@testing-library/react';
import { MealsMock } from '../fixture/MealMocks';
import { DietFor } from './DietFor';
import { useApi } from './hooks/useApi';

jest.mock('./hooks/useApi');

describe('DietFor', () => {
    it('should render loading indicator when loading', () => {

        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: true,
            error: undefined,
        });

        render(<DietFor date={new Date()} />);

        expect(screen.getByRole('progressbar')).toBeInTheDocument();
    });

    it('should render error when error', () => {
        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: false,
            error: 'error',
        });

        render(<DietFor date={new Date()} />);
        const error = screen.getByRole('alert');

        expect(error).toBeInTheDocument();
        expect(error).toHaveTextContent('Wystąpił bład podczas ładowania posiłków: error');
    });

    it('should render meals when loaded', () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealsMock,
            loading: false,
            error: undefined,
        });

        render(<DietFor date={new Date()} />);
        const meals = screen.getByTestId('meals');
        expect(meals).toBeInTheDocument();
    });
});
