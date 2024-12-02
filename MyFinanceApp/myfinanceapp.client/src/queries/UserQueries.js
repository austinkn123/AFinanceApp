import { useContext } from 'react';
import axiosInstance from './shared/axios';
import { useGoogleLogin } from '@react-oauth/google';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../AuthContext';

export const getAllUsers = () => {
    return axiosInstance.get(`users`);
};

export const AwsLogin = (loginData) => {
    return axiosInstance.post(`users/login`, loginData);
};

export const AwsSignUp = (signUpData) => {
    return axiosInstance.post(`users/register`, signUpData);
};

export const useGoogleLoginTokens = () => {
    const { login } = useContext(AuthContext);
    const navigate = useNavigate();

    return useGoogleLogin({
        onSuccess: async (response) => {
            try {
                const { access_token } = response;
                const userInfoResponse = await axios.get('https://www.googleapis.com/oauth2/v3/userinfo', {
                    headers: {
                        Authorization: `Bearer ${access_token}`,
                    },
                });
                const userInfo = userInfoResponse.data;
                console.log('User Info:', userInfo);

                // Store tokens in sessionStorage
                sessionStorage.setItem('accessToken', access_token);
                sessionStorage.setItem('idToken', userInfo.sub); // Assuming sub is the ID token

                login();
                navigate('/');
                toast.success('Login successful');
            } catch (error) {
                console.error('Login failed:', error);
                toast.error('Login failed');
            }
        },
        onError: (error) => {
            console.error('Login failed:', error);
            toast.error('Login failed');
        },
    });
};

export const GoogleSignUp = (signUpData) => {
    return axiosInstance.post(`users/register`, signUpData);
};