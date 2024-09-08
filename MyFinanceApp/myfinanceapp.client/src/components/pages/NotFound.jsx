import { Typography, Box } from '@mui/material';
import DangerousIcon from '@mui/icons-material/Dangerous';

const NotFound = () => {
    return (
        <Box
            display="flex"
            justifyContent="center"
            alignItems="center"
            minHeight="100vh"
            bgcolor="background.default"
            color="text.primary"
            flexDirection="column"
        >
            <Typography variant="h1" component="h1" gutterBottom>
                404
            </Typography>
            <DangerousIcon sx={{ fontSize: 100, color: 'error.main', mb: 4 }} />
            <Typography variant="h4" component="p">
                Page Not Found
            </Typography>
        </Box>
    );
};

export default NotFound