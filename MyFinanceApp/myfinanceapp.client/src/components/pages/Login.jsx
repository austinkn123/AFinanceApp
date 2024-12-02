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
import { useGoogleLogin } from '@react-oauth/google';
import { useGoogleLoginTokens, AwsLogin } from '../../queries/UserQueries';
import { toast } from 'react-toastify';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import LoginWindow from '../organisms/LoginWindow';

const loginSchema = yup.object().shape({
    user_Name: yup.string().required('User name is required').max(100, 'Too long'),
    password: yup.string().required('Password is required').max(100, 'Too long'),
});

const Login = () => {
    const navigate = useNavigate();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);

    



    useEffect(() => {
        sessionStorage.clear();
    }, []);

    return (
        <Box
            sx={{
                backgroundColor: 'background.default',
                minHeight: '100vh',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                padding: 2,
            }}
        >
            <LoginWindow />
        </Box>
    );
};

export default Login;
