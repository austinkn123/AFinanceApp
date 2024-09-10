import { Box } from '@mui/material';
import DangerousIcon from '@mui/icons-material/Dangerous';
import PageHeader from '../atoms/PageHeader';

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
            <PageHeader title="404" size="h1" />
            <DangerousIcon sx={{ fontSize: 100, color: 'error.main', my: 4 }} />
            <PageHeader title="Page Not Found" size="h4" />

        </Box>
    );
};

export default NotFound