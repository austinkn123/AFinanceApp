import React, { useRef } from 'react';
import { Box, IconButton } from '@mui/material';
import { ArrowBackIos, ArrowForwardIos } from '@mui/icons-material';
import CardMolecule from '../molecules/CardMolecule';

const GoalsCardSlide = () => {
    const carouselRef = useRef(null);

    const scrollLeft = () => {
        carouselRef.current.scrollBy({
            top: 0,
            left: -100, // Adjust based on card width
            behavior: 'smooth',
        });
    };

    const scrollRight = () => {
        carouselRef.current.scrollBy({
            top: 0,
            left: 100, // Adjust based on card width
            behavior: 'smooth',
        });
    };

    return (
        <Box display="flex" alignItems="center">
            <IconButton onClick={scrollLeft}>
                <ArrowBackIos />
            </IconButton>
            <Box
                ref={carouselRef}
                display="flex"
                overflow="hidden" // Hide the scrollbars
                sx={{ scrollSnapType: 'x mandatory', overflowY: 'hidden', gap: 2 }}
                width="100%"
            >
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
                <Box sx={{ scrollSnapAlign: 'start' }}>
                    <CardMolecule />
                </Box>
            </Box>
            <IconButton onClick={scrollRight}>
                <ArrowForwardIos />
            </IconButton>
        </Box>
    );
};

export default GoalsCardSlide;