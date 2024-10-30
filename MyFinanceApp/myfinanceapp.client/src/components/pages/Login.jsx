import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { GoogleOAuthProvider, GoogleLogin } from '@react-oauth/google';

const Login = ({ setAuth }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleGoogleLoginSuccess = (response) => {
        const idToken = response.credential;
        // Send the idToken to your server
        fetch('/api/users/google-login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ idToken })
        })
            .then(response => response.json())
            .then(data => {
                console.log('Login successful:', data);
                setAuth(true);
                navigate('/');
            })
            .catch(error => {
                console.error('Error during login:', error);
                alert('Google login failed');
            });
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
        <GoogleOAuthProvider clientId="YOUR_GOOGLE_CLIENT_ID">
            <div>
                <h2>Login</h2>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>Username:</label>
                        <input
                            type="text"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div>
                        <label>Password:</label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <button type="submit">Login</button>
                </form>
                <GoogleLogin
                    onSuccess={handleGoogleLoginSuccess}
                    onError={handleGoogleLoginFailure}
                />
            </div>
        </GoogleOAuthProvider>
    );
};

export default Login;