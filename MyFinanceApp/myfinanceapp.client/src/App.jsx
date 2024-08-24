import { useState } from 'react';
import { ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { lightTheme, darkTheme } from './Theme.js';
import NavBar from './components/organisms/NavBar.jsx';

function App() {
    const [isDarkMode, setIsDarkMode] = useState(false);


    return (
        <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
            <CssBaseline /> {/* This resets the CSS to a consistent baseline */}
            <div>
                <NavBar isDarkMode={isDarkMode} setIsDarkMode={setIsDarkMode} />
                <h1>
                    Helloootrhrteh
                </h1>
                
                {/* Your app components go here */}
            </div>
        </ThemeProvider>
    );
}

export default App;
