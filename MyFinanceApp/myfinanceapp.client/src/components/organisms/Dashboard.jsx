import BarChartAtom from "../atoms/BarChartAtom";
import CalendarAtom from "../atoms/CalendarAtom";
import PageHeader from "../atoms/PageHeader";
import PieChartAtom from "../atoms/PieChartAtom";
import { Box } from '@mui/material';


const Dashboard = () => {
    return (
        <Box mt={7}>
            {/* First row: Pie Chart and Calendar side by side or stacked on small screens */}
            <Box
                display="flex"
                justifyContent="space-between"
                mb={2}
                flexDirection={{ xs: 'column', md: 'row' }} // Stack on small screens (xs), side by side on medium (md) and up

            >
                <Box
                    flex={1}
                    maxWidth={{ xs: '100%', md: '50%' }}
                    pr={{ md: 1 }}
                    mb={{ xs: 2, md: 0 }}
                    maxHeight={{ xs: '100%', md: '50%' }}
                    sx={{ backgroundColor: 'primary.main', borderRadius: 2, p: 2 }} // White background and rounded corners
                    m={2}

                >
                    <Box display="flex" justifyContent="center" p={2}>
                        <PageHeader title="Budget" size="h4" />
                    </Box>
                    
                    <PieChartAtom />
                </Box>
                <Box
                    flex={1}
                    maxWidth={{ xs: '100%', md: '50%' }}
                    pr={{ md: 1 }}
                    mb={{ xs: 2, md: 0 }}
                    maxHeight={{ xs: '100%', md: '50%' }}
                    sx={{ backgroundColor: 'primary.main',  borderRadius: 2, p: 2 }} // White background and rounded corners
                    m={2}
                >
                    <Box display="flex" justifyContent="center" p={2}>
                        <PageHeader title="Logging" size="h4" />
                    </Box>
                    <CalendarAtom />
                </Box>
            </Box>

            {/* Second row: Bar chart fills the entire row */}
            <Box
                width="100%"
                sx={{ backgroundColor: 'primary.main', borderRadius: 2, p: 2 }} // White background and rounded corners
                mr={2}
            >
                <Box display="flex" justifyContent="center" p={2} >
                    <PageHeader title="Spending" size="h4" />
                </Box>
                <BarChartAtom />
            </Box>
        </Box>
    );
}

export default Dashboard;
