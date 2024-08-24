import { useState } from 'react';
import { ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { lightTheme, darkTheme } from './Theme.js';
import NavBar from './components/organisms/NavBar.jsx';
import {
    BrowserRouter as Router,
    Route,
    Routes,
    Navigate
} from "react-router-dom";
import Home from './components/pages/Home.jsx';
import SpendingLogs from './components/pages/SpendingLog.jsx';
import BudgetPlans from './components/pages/BudgetPlans.jsx';
import Goals from './components/pages/Goals.jsx';
import NewsFeed from './components/pages/NewsFeed.jsx';
import Profile from './components/pages/Profile.jsx';
import Login from './components/pages/Login.jsx';
import NotFound from './components/pages/NotFound.jsx';

function App() {
    const [isDarkMode, setIsDarkMode] = useState(false);


    return (
        <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
            <CssBaseline /> {/* This resets the CSS to a consistent baseline */}
            <div>
               


                <Router>
                    <NavBar isDarkMode={isDarkMode} setIsDarkMode={setIsDarkMode} />
                    <Routes>
                        <Route path='/Home' element={<Home />} />
                        <Route path='/spending' element={<SpendingLogs />} />
                        <Route path='/budget' element={<BudgetPlans />} />
                        <Route path='/goals' element={<Goals />} />
                        <Route path='/news' element={<NewsFeed />} />
                        <Route path='/profile' element={<Profile />} />
                        <Route path='/login' element={<Login />} />
                        <Route path='/not-found' element={<NotFound />} />
                        <Route path='*' element={<Navigate to='/not-found' />} />
                    </Routes>
                </Router>
                {/* Your app components go here */}
            </div>
        </ThemeProvider>
    );
}

export default App;
