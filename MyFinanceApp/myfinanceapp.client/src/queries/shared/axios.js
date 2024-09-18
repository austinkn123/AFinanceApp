import axios from 'axios';

// Create an instance of Axios with a base URL
const axiosInstance = axios.create({
    baseURL: '/api', // This will be proxied to the target defined in Vite
    headers: {
        'Content-Type': 'application/json',
    },
});
export default axiosInstance;