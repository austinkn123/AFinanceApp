import axiosInstance from './shared/axios';

export const getAllUsers = () => {
    return axiosInstance.get(`users`);
};

export const AwsLogin = (loginData) => {
    return axiosInstance.post(`users/login`, loginData);
};

export const AwsSignUp = (signUpData) => {
    return axiosInstance.post(`users/register`, signUpData);
};

export const GoogleLogin = (loginData) => {
    return axiosInstance.post(`users/login`, loginData);
};

export const GoogleSignUp = (signUpData) => {
    return axiosInstance.post(`users/register`, signUpData);
};