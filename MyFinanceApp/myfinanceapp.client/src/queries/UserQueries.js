import axiosInstance from './shared/axios';

export const getAllUsers = () => {
    return axiosInstance.get(`users`);
};