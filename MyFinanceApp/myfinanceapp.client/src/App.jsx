import { useState, useContext } from 'react';
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
import { GoogleOAuthProvider } from '@react-oauth/google';
import Home from './components/pages/Home.jsx';
import SpendingLogs from './components/pages/SpendingLog.jsx';
import BudgetPlans from './components/pages/BudgetPlans.jsx';
import Goals from './components/pages/Goals.jsx';
import NewsFeed from './components/pages/NewsFeed.jsx';
import Profile from './components/pages/Profile.jsx';
import Login from './components/pages/Login.jsx';
import NotFound from './components/pages/NotFound.jsx';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { AuthProvider, AuthContext } from './AuthContext';
import OAuth2Callback from './components/organisms/OAuth2Callback';

function App() {
    const [isDarkMode, setIsDarkMode] = useState(false);
    const { isAuthenticated } = useContext(AuthContext);
    console.log("isAuthenticated APP:", isAuthenticated);
    return (
        <GoogleOAuthProvider clientId="495058288143-kfktsiduls935pmd1g15gmlrp7h96k12.apps.googleusercontent.com">
            <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
                <CssBaseline /> {/* This resets the CSS to a consistent baseline */}
                <div>
                    <Router>
                        {isAuthenticated && <NavBar isDarkMode={isDarkMode} setIsDarkMode={setIsDarkMode} />}
                        <Routes>
                            {isAuthenticated ? (
                                <>
                                    <Route path='/' element={<Home />} />
                                    <Route path='/spending' element={<SpendingLogs />} />
                                    <Route path='/budget' element={<BudgetPlans />} />
                                    <Route path='/goals' element={<Goals />} />
                                    <Route path='/news' element={<NewsFeed />} />
                                    <Route path='/profile' element={<Profile />} />
                                    <Route path='/not-found' element={<NotFound />} />
                                    <Route path='*' element={<Navigate to='/not-found' />} />
                                </>
                            ) : (
                                <>
                                    <Route path='/login' element={<Login  />} />
                                    <Route path='*' element={<Navigate to='/login' />} />
                                </>
                                    
                            )}
                            <Route path="/oauth2/callback" element={<OAuth2Callback />} />
                                
                        </Routes>
                    </Router>
                    <ToastContainer />
                </div>
            </ThemeProvider>
        </GoogleOAuthProvider>

    );
}

export default App;
