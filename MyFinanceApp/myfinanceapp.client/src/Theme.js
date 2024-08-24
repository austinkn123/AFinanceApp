import { createTheme } from '@mui/material/styles';

//#83C9F4
//#A3D5FF
//#D9F0FF
//#272727
//#E6E6E5
//#FFFFFF


const lightTheme = createTheme({
    palette: {
        primary: {
            main: '#83C9F4',  // Primary color
            light: '#A3D5FF', // Lighter shade
            dark: '#272727',  // Darker shade for contrast
        },
        secondary: {
            main: '#D9F0FF',  // Secondary color
        },
        background: {
            default: '#F9F9F9', // Background color
            paper: '#FFFFFF',   // Paper color
        },
        text: {
            primary: '#272727', // Primary text color
            secondary: '#A3D5FF', // Secondary text color (optional)
        },
        spacing: [0, 2, 3, 5, 8],
    },
});

// Define the dark mode color palette
const darkTheme = createTheme({
    palette: {
        mode: 'dark', // This enables dark mode
        primary: {
            main: '#83C9F4',  // Primary color (light blue)
            light: '#A3D5FF', // Lighter shade (blue)
            dark: '#272727',  // Darker shade (dark gray/black)
        },
        secondary: {
            main: '#D9F0FF',  // Secondary color (light blue)
        },
        background: {
            default: '#272727', // Dark background color
            paper: '#383838',   // Darker paper color
        },
        text: {
            primary: '#E6E6E5', // Light gray text color
            secondary: '#FFFFFF', // White text color for contrast
        },
        spacing: [0, 2, 3, 5, 8],
    },
});

export { lightTheme, darkTheme };