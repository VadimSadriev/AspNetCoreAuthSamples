import React from 'react';
import { Backdrop, CircularProgress } from '@material-ui/core';
import { connect } from 'react-redux';
import './style.scss';

class LayoutBackdrop extends React.Component {

    render() {
        return (
            <React.Fragment>
                <Backdrop className="global-backdrop" open={this.props.isOpen}>
                    <CircularProgress color="inherit" />
                </Backdrop>
            </React.Fragment>
        )
    }
}

const mapStateToProps = state => {
    return {
        isOpen: state.layoutBackdrop.isOpen
    }
}

export default connect(mapStateToProps)(LayoutBackdrop);