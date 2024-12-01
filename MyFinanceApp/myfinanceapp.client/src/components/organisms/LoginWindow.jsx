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
        <Container maxWidth="sm">
            <Paper elevation={3} sx={{ padding: 4, marginTop: 8 }}>
                <Divider>
                    <Typography variant="h4" component="h1" gutterBottom align="center">
                        Login
                    </Typography>
                </Divider>
                
                <Formik
                    initialValues={{
                        user_Name: "",
                        password: "",
                    }}
                    validationSchema={loginSchema}
                    validateOnBlur={false}
                    validateOnChange={false}
                    onSubmit={async (values) => {
                        try {
                            const response = await AwsLogin(values); // Call AwsLogin with form values
                            console.log(response.data);
                            sessionStorage.setItem('authToken', response.data.token);
                            navigate('/');
                            toast.success('Login successful');
                        } catch (error) {
                            console.error('Login failed:', error);
                            toast.error('Invalid credentials');
                            
                        } 
                    }}
                >
                    {({ handleSubmit, isSubmitting }) => (
                        <Form onSubmit={handleSubmit}>
                            <Box mb={2}>
                                <Field name="user_Name">
                                    {({ field, meta }) => (
                                        <TextField
                                            {...field} //Contains properties like name, value, onChange, and onBlur.
                                            // field.name will be "user_Name".
                                            // field.value will be the current value of the user_Name field.
                                            // field.onChange will update the value of the user_Name field in Formik's state.
                                            // field.onBlur will mark the user_Name field as "touched" in Formik's state.
                                            label="User Name"
                                            error={meta.touched && meta.error}
                                            helperText={meta.touched && meta.error} //meta: Contains metadata about the field, such as touched and error.
                                            variant="outlined"
                                            fullWidth
                                            margin="normal"
                                        />
                                    )}
                                </Field>
                            </Box>
                            <Box mb={2}>
                                <Field name="password">
                                    {({ field, meta }) => (
                                        <TextField
                                            {...field}
                                            label="Password"
                                            type={showPassword ? 'text' : 'password'}
                                            error={meta.touched && meta.error}
                                            helperText={meta.touched && meta.error}
                                            variant="outlined"
                                            fullWidth
                                            margin="normal"
                                            InputProps={{
                                                endAdornment: ( // InputAdornment is used to place the IconButton at the end of the TextField.
                                                    <IconButton
                                                        aria-label="toggle password visibility"
                                                        onClick={() => {
                                                            setShowPassword(!showPassword);
                                                        }}
                                                        edge="end"
                                                    >
                                                        {showPassword ? <VisibilityOff /> : <Visibility />}
                                                    </IconButton>
                                                ),
                                            }}
                                        />
                                    )}
                                </Field>
                            </Box>
                            <Box mt={3}>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    type="submit"
                                    disabled={isSubmitting}
                                    fullWidth
                                >
                                    Login
                                </Button>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    onClick={handleGoogleLoginSuccess}
                                    fullWidth
                                    sx={{ marginTop: 2 }}
                                >
                                    Google Login
                                </Button>
                            </Box>
                            
                            
                        </Form>
                    )}
                </Formik>
                <Box mt={5}>
                    <Divider>
                        <Typography variant="h4" component="h1" gutterBottom align="center">
                            Sign Up
                        </Typography>
                    </Divider>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleGoogleLoginSuccess}
                        fullWidth
                        sx={{ marginTop: 2 }}
                    >
                        Sign Up
                    </Button>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={() => console.log("Google Sign up") }
                        fullWidth
                        sx={{ marginTop: 2 }}
                    >
                        Google Sign up
                    </Button>
                </Box>
            </Paper>
        </Container>
    );
}

export default LoginWindow;
