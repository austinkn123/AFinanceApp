import React, { useEffect } from 'react';
import PageHeader from '../atoms/PageHeader';
import { Box } from '@mui/material';
import GoalsCardSlide from '../organisms/GoalsCardSlide';
import Dashboard from '../organisms/Dashboard';
import { getAllUsers } from '../../queries/UserQueries';



const Home = () => {
    // Define an asynchronous function to fetch and log the data
    const fetchUsers = async () => {
        try {
            const response = await getAllUsers(); // Wait for the promise to resolve
            console.log("USERS", response.data); // Log the data from the response
        } catch (error) {
            console.error("Error fetching users:", error);
        }
    };

    // Call the function when the component is rendered
    useEffect(() => {
        fetchUsers();
    }, []); // Empty dependency array means it will run once when the component mounts
    return (
        <Box p={4}>
            <Box display="flex" justifyContent="center" p={2}>
                <PageHeader title="How are your finances doing?" size="h2" />
            </Box>
            <Box >
                <PageHeader title="Goals" size="h4" />
                <GoalsCardSlide />
            </Box>
            <Box mt={6} >
                <Box display="flex" justifyContent="center" p={2}>
                    <PageHeader title="Your Habits" size="h3" />
                </Box>
                <Dashboard />
            </Box>
            
            
        </Box>
        
    )
}

export default Home