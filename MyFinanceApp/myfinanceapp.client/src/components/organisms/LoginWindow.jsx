import React, { useState, useContext } from 'react';
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
import { useGoogleLoginTokens, AwsLogin } from '../../queries/UserQueries';
import { toast } from 'react-toastify';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import { AuthContext } from '../../AuthContext';

const loginSchema = yup.object().shape({
    user_Name: yup.string().required('User name is required').max(100, 'Too long'),
    password: yup.string().required('Password is required').max(100, 'Too long'),
});

const LoginWindow = () => {

    const navigate = useNavigate();
    const { login, isAuthenticated } = useContext(AuthContext);

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);

    const googleLogin = useGoogleLoginTokens();

    const handleGoogleLoginSuccess = () => {
        const callbackUrl = `${window.location.origin}/oauth2/callback`;
        const googleClientId = "495058288143-kfktsiduls935pmd1g15gmlrp7h96k12.apps.googleusercontent.com";
        const state = encodeURIComponent(Math.random().toString(36).substring(2)); // Generate a random state parameter
        const targetUrl = `https://accounts.google.com/o/oauth2/v2/auth?client_id=${googleClientId}&redirect_uri=${encodeURIComponent(
            callbackUrl
        )}&response_type=code&scope=openid%20email%20profile&state=${state}&access_type=offline&service=lso&o2v=2&ddm=1&flowName=GeneralOAuthFlow`;
        //redirects the user's browser to the constructed Google OAuth URL
        console.log(targetUrl);
        window.location.href = targetUrl;
    };

    const handleGoogleLoginFailure = (error) => {
        console.error('Login failed:', error);
        alert('Google login failed');
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
                            login();
                            console.log("isAuthenticated:", isAuthenticated);

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
                                    onClick={() => useGoogleLoginTokens()}
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
                </Box>
            </Paper>
        </Container>
    );
}

export default LoginWindow;
