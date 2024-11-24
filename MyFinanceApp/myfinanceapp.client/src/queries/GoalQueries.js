import axiosInstance from './shared/axios';

export const getAllGoals = () => {
    return axiosInstance.get(`goals`);
};