import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { withSnackbar } from 'notistack';
import { Close } from '@material-ui/icons';
import { IconButton, Button } from '@material-ui/core';
import { removeSnackbar } from '../../../store/actions/layoutSnackbar';
import CustomSnackbar from './components/customSnackbar';

// https://iamhosseindhv.com/notistack/demos#action-for-all-snackbars
// https://github.com/iamhosseindhv/notistack#documentation

const defaultOptions = {
    anchorOrigin: {
        vertical: 'top',
        horizontal: 'right'
    }
}

class LayoutSnackbar extends React.Component {

    constructor(props) {
        super(props)
        this.displayed = [];
    }

    storeDisplayed = (key) => {
        this.displayed = [...this.displayed, key];
    };

    removeDisplayed = (id) => {
        this.displayed = this.displayed.filter(key => id !== key)
    }

    componentDidUpdate() {
        const { notifications = [] } = this.props;

        notifications.forEach(({ key, message, options = {}, dismissed = false }) => {
            if (dismissed) {
                this.props.closeSnackbar(key)
                return;
            }
            // Do nothing if snackbar is already displayed
            if (this.displayed.includes(key)) return;
            // Display snackbar using notistack
            this.props.enqueueSnackbar(message, {
                key,
                ...defaultOptions,
                ...options,
                action: key => (
                    <Button onClick={() => this.props.closeSnackbar(key)}>
                        <Close fontSize='small' />
                    </Button>),
                onClose: (event, reason, key) => {
                    if (options.onClose) {
                        options.onClose(event, reason, key);
                    }
                },
                onExited: (event, key) => {
                    this.props.removeSnackbar(key);
                    this.removeDisplayed(key)
                }
            });
            // Keep track of snackbars that we've displayed
            this.storeDisplayed(key);
        });
    }

    render() {
        return null;
    }
}

const mapStateToProps = state => {
    return {
        notifications: state.layoutSnackbar.notifications
    }
}

const mapDispatchToProps = dispatch => bindActionCreators({ removeSnackbar }, dispatch);

const layoutWithSnackbar = withSnackbar(LayoutSnackbar);

export default connect(mapStateToProps, mapDispatchToProps)(layoutWithSnackbar);