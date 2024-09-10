import PageHeader from '../atoms/PageHeader';
import { Box } from '@mui/material';
import GoalsCardSlide from '../organisms/GoalsCardSlide';
import Dashboard from '../organisms/Dashboard';



const Home = () => {

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