import React from 'react';
import Navbar from '../navbar';
import { Container } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import LayoutBackdrop from '../feedback/backdrop';
import LayoutSnackbar from '../feedback/snackbar';
import './style.scss';

const styles = theme => ({
    // made for spacing due to fixed navbar
    toolbar: theme.mixins.toolbar,
});

class Layout extends React.Component {

    constructor(props) {
        super(props);
        const { classes } = props;
        this.classes = classes;
    }

    render() {
        return (
            <div>
                <Navbar />
                <div className={this.classes.toolbar} />
                <LayoutBackdrop />
                <LayoutSnackbar />
                <Container maxWidth={'xl'}>
                    {this.props.children}
                </Container>
            </div>
        )
    }
}

export default withStyles(styles)(Layout);