import PageHeader from '../atoms/PageHeader';
import { Box } from '@mui/material';
import GoalsCardSlide from '../organisms/GoalsCardSlide';
import Dashboard from '../organisms/Dashboard';



const Home = () => {

    return (
        <>
            <Box display="flex" justifyContent="center" p={2}>
                <PageHeader title="How are your finances doing?" size="h2" />
                
            </Box>
            <Box >
                <PageHeader title="Goals" size="h4" />
                <GoalsCardSlide />
            </Box>
            <PageHeader title="Your Habits" size="h4" />
            <Dashboard />
            
        </>
        
    )
}

export default Home