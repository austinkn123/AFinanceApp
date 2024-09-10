import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import CardActionArea from '@mui/material/CardActionArea';

//future goal: ability to add pictures
const CardComponent = () => {

    return (
        <>

            <Card sx={{ maxWidth: 345 }}>
                <CardActionArea sx={{ width: '300px', height: '150px', }}>
                    {/*<CardMedia*/}
                    {/*    component="img"*/}
                    {/*    height="140"*/}
                    {/*    image="/static/images/cards/contemplative-reptile.jpg"*/}
                    {/*    alt="green iguana"*/}
                    {/*/>*/}
                    <CardContent>
                        <Typography gutterBottom sx={{ color: 'text.secondary', fontSize: 14 }}>
                            Goal 1
                        </Typography>
                        <Typography variant="h5" component="div">
                            Title
                        </Typography>
                        <br />
                        <Typography variant="body2">
                            Description
                            <br />
                        </Typography>
                    </CardContent>
                </CardActionArea>
            </Card>
        </>
    )
}

export default CardComponent