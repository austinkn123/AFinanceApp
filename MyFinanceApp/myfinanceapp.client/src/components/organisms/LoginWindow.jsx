import React, { useState, useEffect } from 'react';
import { Formik, Form, Field } from 'formik';
import {
    TextField,
    Button,
    Box,
    Typography,
    Container,
    Paper,
    Divider,
    IconButton
} from '@mui/material';
import * as yup from 'yup';
import { useNavigate } from 'react-router-dom';
import { GoogleLogin } from '@react-oauth/google';
import { AwsLogin } from '../../queries/UserQueries';
import { toast } from 'react-toastify';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';

const loginSchema = yup.object().shape({
    user_Name: yup.string().required('User name is required').max(100, 'Too long'),
    password: yup.string().required('Password is required').max(100, 'Too long'),
});

const LoginWindow = () => {

    const navigate = useNavigate();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);

    const handleGoogleLoginSuccess = () => {
        const callbackUrl = `${window.location.origin}`;
        const googleClientId = "495058288143 - kfktsiduls935pmd1g15gmlrp7h96k12.apps.googleusercontent.com";
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
        
    );
}

export default LoginWindow;
