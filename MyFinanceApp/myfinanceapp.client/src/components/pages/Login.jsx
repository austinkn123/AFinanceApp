import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { GoogleLogin } from '@react-oauth/google';
import LoginWindow from '../organisms/LoginWindow';

const Login = ({ setAuth }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleGoogleLoginSuccess = () => {
        const callbackUrl = `${window.location.origin}`;
        const googleClientId = "YOUR_CLIENT_ID_FROM_GOOGLE";
        const targetUrl = `https://accounts.google.com/o/oauth2/auth?redirect_uri=${encodeURIComponent(
            callbackUrl
        )}&response_type=token&client_id=${googleClientId}&scope=openid%20email%20profile`;
        //redirects the user's browser to the constructed Google OAuth URL
        window.location.href = targetUrl;
    };

    const handleGoogleLoginFailure = (error) => {
        console.error('Login failed:', error);
        alert('Google login failed');
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Replace with actual authentication logic
        if (username === 'user' && password === 'password') {
            setAuth(true);
            navigate('/');
        } else {
            alert('Invalid credentials');
        }
    };

    return (
            <div>
            <h2>Login</h2>
                <LoginWindow />
                {/*<GoogleLogin*/}
                {/*    onSuccess={handleGoogleLoginSuccess}*/}
                {/*    onError={handleGoogleLoginFailure}*/}
                {/*/>*/}
                <button onClick={handleGoogleLoginSuccess}>
                    Google Login
                </button>
            </div>
    );
};

export default Login;