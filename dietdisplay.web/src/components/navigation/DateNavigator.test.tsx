import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import { MealRangeMock } from '../../fixture/MealRangeMock';
import { addDays, getCurrentDate, getDate } from '../../helpers/dateHelper';
import { useApi } from '../api/useApi';
import { DateNavigator } from './DateNavigator';

jest.mock('../api/useApi');
jest.mock('@mui/material/useMediaQuery');

describe('DateNavigator', () => {    
    it('should render date', () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const date = screen.getByText(new Date().toLocaleDateString());
        expect(date).toBeInTheDocument();
    });

    it('should render next date when clicked', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const nextDate = addDays(1);
        await userEvent.click(screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` }));
        const date = screen.getByText(nextDate.toLocaleDateString());
        expect(date).toBeInTheDocument();
    });

    it('should call onDateChange when clicked', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });

        const onDateChange = jest.fn();
        render(<DateNavigator currentDate={getCurrentDate()} onDateChange={onDateChange} />);
        const nextDate = addDays(1);
        await userEvent.click(screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` }));
        expect(onDateChange).toHaveBeenCalledWith(nextDate);
    });

    it('should make next button disabled if next date is later than newest date from API', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={getDate(MealRangeMock.newestDate)} />);
        const nextDate = addDays(1, MealRangeMock.newestDate);
        const button = screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` });
        expect(button).toBeDisabled();
    });

    it('should make next button enabled if next date is earlier than newest date from API', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={addDays(-1, MealRangeMock.newestDate)} />);
        const nextDate = getDate(MealRangeMock.newestDate);
        const button = screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` });
        expect(button).toBeEnabled();
    });

    it('should make next button disabled if MealRange is loading', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: true,
            error: undefined,
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const nextDate = addDays(1);
        const button = screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` });
        expect(button).toBeDisabled();
    });

    it('should make next button disabled if MealRange returns an error', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: false,
            error: "error",
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const nextDate = addDays(1);
        const button = screen.getByRole('button', { name: `${nextDate.toLocaleDateString()} >` });
        expect(button).toBeDisabled();
    });

    it('should make previous button disabled if previous date is older than oldest date from api', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={getDate(MealRangeMock.oldestDate)} />);
        const previousDate = addDays(-1, MealRangeMock.oldestDate);
        const button = screen.getByRole('button', { name: `< ${previousDate.toLocaleDateString()}` });
        expect(button).toBeDisabled();
    });

    it('should make previous button enabled if previous date is later than oldest date from api', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={addDays(2, MealRangeMock.oldestDate)} />);
        const previousDate = addDays(1, MealRangeMock.oldestDate);
        const button = screen.getByRole('button', { name: `< ${previousDate.toLocaleDateString()}` });
        expect(button).toBeEnabled();
    });

    it('should make previous button disabled if MealRange is loading', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: true,
            error: undefined,
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const previousDate = addDays(-1);
        const button = screen.getByRole('button', { name: `< ${previousDate.toLocaleDateString()}` });
        expect(button).toBeDisabled();
    });

    it('should make previous button disabled if MealRange returns an error', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: undefined,
            loading: false,
            error: "error",
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const previousDate = addDays(-1);
        const button = screen.getByRole('button', { name: `< ${previousDate.toLocaleDateString()}` });
        expect(button).toBeDisabled();
    });

    it('should render previous date when clicked', async () => {
        (useApi as jest.Mock).mockReturnValue({
            data: MealRangeMock,
            loading: false,
            error: undefined,
        });
        render(<DateNavigator currentDate={getCurrentDate()} />);
        const previousDate = addDays(-1);
        await userEvent.click(screen.getByRole('button', { name: `< ${previousDate.toLocaleDateString()}` }));
        const date = screen.getByText(previousDate.toLocaleDateString());
        expect(date).toBeInTheDocument();
    });
});