import React from 'react';
import { connect } from 'react-redux';
import { Snackbar } from '@material-ui/core';
import { withSnackbar } from 'notistack';

// export const withUserSnackbar = Component => {
//     return props => {

//         const { enqueueSnackbar } = useSnackbar();

//         return <Component enqueueSnackbar={enqueueSnackbar} {...props}></Component>;
//     }
// }

const defaultOptions = {
    anchorOrigin: {
        vertical: 'top',
        horizontal: 'right'
    }
}

class LayoutSnackbar extends React.Component {

    state = {
        isOpen: true,
        vertical: 'top',
        horizontal: 'right'
    }

    handleClick = () => {
        const key = this.props.enqueueSnackbar('i love snacks', {
            ...defaultOptions,
        });
    }
    // https://iamhosseindhv.com/notistack/demos#action-for-all-snackbars
    // https://github.com/iamhosseindhv/notistack#documentation
    render() {
        return (
            <React.Fragment>
                <button type='button' onClick={this.handleClick}>Show snackbar</button>
            </React.Fragment>
        )
    }
}

const mapStateToProps = state => {
    return {
        messages: state.layoutSnackbar.messages
    }
}

const layoutWithSnackbar = withSnackbar(LayoutSnackbar);

// const test = withUserSnackbar(LayoutSnackbar)

export default connect(mapStateToProps)(layoutWithSnackbar);