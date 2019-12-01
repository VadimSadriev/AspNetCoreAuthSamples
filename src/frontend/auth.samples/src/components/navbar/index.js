import React from 'react';
import { Link } from 'react-router-dom';
import {
    AppBar,
    Toolbar,
    Button,
    Typography
} from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import './style.scss';

const styles = theme => ({
    title: {
        // flexGrow: 1,
    }
});

class Navbar extends React.Component {

    constructor(props) {
        super(props);
        const { classes } = props;
        this.classes = classes;
    }

    render() {
        return (
            <div>
                <AppBar position='fixed' color='default'>
                    <Toolbar className='nav-menu'>
                        <Typography variant="h6" component={Link} to='/' className='nav-brand'>
                            Auth Samples
                        </Typography>
                        <div className='links'>
                            <Button className={this.classes.button} component={Link} to='/register'>Register</Button>
                        </div>
                    </Toolbar>
                </AppBar>
            </div>
        )
    }
}

export default withStyles(styles)(Navbar);