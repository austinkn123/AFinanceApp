import { Typography } from '@mui/material';


const PageHeader = ( {title, size} ) => {

    return (
        <>

            <Typography variant={size} component={size} >
                {title}
            </Typography>
        </>
    )
}

export default PageHeader