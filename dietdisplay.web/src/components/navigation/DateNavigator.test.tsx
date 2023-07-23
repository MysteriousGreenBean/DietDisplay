import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import { getCurrentDate } from '../../helpers/dateHelper';
import { DateNavigator } from './DateNavigator';

describe('DateNavigator', () => {
    it('should render date', () => {
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const date = screen.getByText(new Date().toLocaleDateString());
        expect(date).toBeInTheDocument();
    });

    it('should render next date when clicked', async () => {
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const nextDate = getCurrentDate();
        nextDate.setDate(nextDate.getDate() + 1);
        await userEvent.click(screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` }));
        const date = screen.getByText(nextDate.toLocaleDateString());
        expect(date).toBeInTheDocument();
    });

    it('should call onDateChange when clicked', async () => {
        const onDateChange = jest.fn();
        render(<DateNavigator currentDate={getCurrentDate()} onDateChange={onDateChange} />);
        const nextDate = getCurrentDate();
        nextDate.setDate(nextDate.getDate() + 1);
        await userEvent.click(screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` }));
        expect(onDateChange).toHaveBeenCalledWith(nextDate);
    });
});