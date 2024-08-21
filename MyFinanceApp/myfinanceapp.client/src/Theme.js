import { createTheme } from '@mui/material/styles';

const lightTheme = createTheme({
    palette: {
        primary: {
            main: '#000501',  // Dark greenish-black
            contrastText: '#FFFFFF', // White text on primary
        },
        secondary: {
            main: '#73AB84',  // Medium green
            contrastText: '#FFFFFF', // White text on secondary
        },
        background: {
            default: '#FFFFFF',  // White background
            paper: '#FFFFFF',  // White paper background
        },
        text: {
            primary: '#000501',  // Primary text color
            secondary: '#73AB84',  // Secondary text color
        },
        success: {
            main: '#99D19C',  // Light green
        },
        info: {
            main: '#79C7C5',  // Light teal
        },
        warning: {
            main: '#ADE1E5',  // Light cyan
        },
    },
    typography: {
        fontFamily: 'Roboto, Arial, sans-serif',
    },
});

const darkTheme = createTheme({
    palette: {
        primary: {
            main: '#73AB84',  // Dark greenish-black
            contrastText: '#FFFFFF', // White text on primary
        },
        secondary: {
            main: '#99D19C',  // Medium green
            contrastText: '#FFFFFF', // White text on secondary
        },
        background: {
            default: '#000501',  // White background
            paper: '#FFFFFF',  // White paper background
        },
        text: {
            primary: '#FFFFFF',  // Primary text color
            secondary: '#ADE1E5',  // Secondary text color
        },
        success: {
            main: '#99D19C',  // Light green
        },
        info: {
            main: '#79C7C5',  // Light teal
        },
        warning: {
            main: '#ADE1E5',  // Light cyan
        },
    },
    typography: {
        fontFamily: 'Roboto, Arial, sans-serif',
    },
});

export { lightTheme, darkTheme };
