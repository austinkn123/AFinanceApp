import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useGoogleLoginTokens } from '../../queries/UserQueries';
import { toast } from 'react-toastify';

const OAuth2Callback = () => {
    const navigate = useNavigate();
    const googleLogin = useGoogleLoginTokens();

    useEffect(() => {
        const urlParams = new URLSearchParams(window.location.search);
        const code = urlParams.get('code');
        const state = urlParams.get('state');

        if (code) {
            googleLogin.mutate({ code }, {
                onSuccess: (data) => {
                    sessionStorage.setItem('authToken', data.token);
                    navigate('/');
                    toast.success('Google login successful');
                },
                onError: (error) => {
                    console.error('Login failed:', error);
                    toast.error('Google login failed');
                }
            });
        } else {
            toast.error('No authorization code found');
        }
    }, [googleLogin, navigate]);

    return <div>Loading...</div>;
};

export default OAuth2Callback;
