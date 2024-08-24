/* eslint-disable react/prop-types */
import { useState } from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import ApiOutlinedIcon from '@mui/icons-material/ApiOutlined';
import DarkModeIcon from '@mui/icons-material/DarkMode';
import LightModeIcon from '@mui/icons-material/LightMode';
 
const pages = ['Home', 'Spending', 'Bugdget', 'Goals', 'News'];
const settings = ['Profile', 'Logout'];

const NavBar = ({ isDarkMode, setIsDarkMode }) => {
     const [anchorElNav, setAnchorElNav] = useState(false);
     const [anchorElUser, setAnchorElUser] = useState(false);

     return (
         <AppBar position="static" 
         >
             <Container maxWidth="l">
                 <Toolbar >
                     <ApiOutlinedIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} />
                     <Typography
                         variant="h6"
                         noWrap
                         component="a"
                         href="#app-bar-with-responsive-menu"
                         sx={{
                             mr: 2,
                             display: { xs: 'none', md: 'flex' },
                             fontFamily: 'monospace',
                             fontWeight: 700,
                             color: 'inherit',
                             textDecoration: 'none',
                         }}
                     >
                         My Finance Pal
                     </Typography>


                     <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
                         <IconButton
                             size="large"
                             aria-label="account of current user"
                             aria-controls="menu-appbar"
                             aria-haspopup="true"
                             onClick={(e) => setAnchorElNav(e.currentTarget)}
                             color="inherit"
                         >
                             <MenuIcon />
                         </IconButton>
                         <Menu
                             id="menu-appbar"
                             anchorEl={anchorElNav}
                             anchorOrigin={{
                                 vertical: 'bottom',
                                 horizontal: 'left',
                             }}
                             keepMounted
                             transformOrigin={{
                                 vertical: 'top',
                                 horizontal: 'left',
                             }}
                             open={anchorElNav}
                             onClose={() => setAnchorElNav(null)}
                             sx={{
                                 display: { xs: 'block', md: 'none' },
                             }}
                         >
                             {pages.map((page) => (
                                 <MenuItem key={page} onClick={() => setAnchorElNav(null)} >
                                     <Typography textAlign="center">{page}</Typography>
                                 </MenuItem>
                             ))}
                         </Menu>
                     </Box>
                     <ApiOutlinedIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
                     <Typography
                         variant="h8"
                         component="a"
                         href="#app-bar-with-responsive-menu"
                         sx={{
                             mr: 2,
                             display: { xs: 'flex', md: 'none' },
                             flexGrow: 1,
                             fontFamily: 'monospace',
                             fontWeight: 700,
                             color: 'inherit',
                             textDecoration: 'none',
                         }}
                     >
                         My Finance Pal
                     </Typography>
                     <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                         {pages.map((page) => (
                             <Button
                                 key={page}
                                 onClick={() => setAnchorElNav(null)}
                                 sx={{ mr: 1, my: 2, color: 'white', display: 'block' }}
                             >
                                 {page}
                             </Button>
                         ))}
                     </Box>
                     {
                         isDarkMode ?
                            <Tooltip title="Toggle Mode" >
                                <span onClick={() => setIsDarkMode(false)}>
                                    <DarkModeIcon sx={{ mt: 1 }}/>
                                </span>
                            </Tooltip>
                             :
                            <Tooltip title="Toggle Mode">
                                <span onClick={() => setIsDarkMode(true)}>
                                    <LightModeIcon sx={{ mt: 1 }}/>
                                </span>
                            </Tooltip>
                     }
                    <Box sx={{ flexGrow: 0 }}>
                         <IconButton onClick={(e) => setAnchorElUser(e.currentTarget)} sx={{ p: 2 }}>
                             <Avatar />
                         </IconButton>
                         <Menu
                             sx={{ mt: '45px' }}
                             id="menu-appbar"
                             anchorEl={anchorElUser}
                             anchorOrigin={{
                                 vertical: 'top',
                                 horizontal: 'right',
                             }}
                             keepMounted
                             transformOrigin={{
                                 vertical: 'top',
                                 horizontal: 'right',
                             }}
                             open={anchorElUser}
                             onClose={() => setAnchorElUser(null)}
                         >
                             {settings.map((setting) => (
                                 <MenuItem key={setting} onClick={() => setAnchorElUser(null)}>
                                     <Typography textAlign="center">{setting}</Typography>
                                 </MenuItem>
                             ))}
                         </Menu>
                     </Box>
                 </Toolbar>
             </Container>
         </AppBar>
     );
 }

export default NavBar