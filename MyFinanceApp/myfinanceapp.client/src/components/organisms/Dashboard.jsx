import BarChartAtom from "../atoms/BarChartAtom";
import CalendarAtom from "../atoms/CalendarAtom";
import PieChartAtom from "../atoms/PieChartAtom";
import { Box } from '@mui/material';

const Dashboard = () => {
    return (
        <Box p={2}>
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
                    display="flex"
                    alignItems="center"
                    justifyContent="center" // Center content vertically and horizontally
                    height="100%" // Ensure the Box takes up full height
                    mt={7}
                >
                    <PieChartAtom />
                </Box>
                <Box flex={1} maxWidth={{ xs: '100%', md: '50%' }} pl={{ md: 1 }}>
                    <CalendarAtom />
                </Box>
            </Box>

            {/* Second row: Bar chart fills the entire row */}
            <Box width="100%">
                <BarChartAtom />
            </Box>
        </Box>
    );
}

export default Dashboard;
