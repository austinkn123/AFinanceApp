import React, { useEffect } from 'react';
import { Box } from '@mui/material';
import LoginWindow from '../organisms/LoginWindow';

const Login = () => {


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
