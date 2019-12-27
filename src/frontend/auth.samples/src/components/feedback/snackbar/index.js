import React, { useState } from 'react';
import { connect } from 'react-redux';
import { Snackbar } from '@material-ui/core';
import { withSnackbar } from 'notistack';
import CustomSnackbar from './components/customSnackbar';


import { withStyles } from '@material-ui/core/styles';
import { useSnackbar } from 'notistack';
import Card from '@material-ui/core/Card';

const styles = theme => ({
    card: {
        maxWidth: 400,
        minWidth: 344,
    },
    typography: {
        fontWeight: 'bold',
    },
    actionRoot: {
        padding: '8px 8px 8px 16px',
        backgroundColor: '#fddc6c',
    },
    action: {
        margin: 0,
    }
});


const SnackMessage = (props) => {
    const { closeSnackbar } = useSnackbar();
    const [expanded, setExpanded] = useState(false);

    const handleExpandClick = () => {
        setExpanded(!expanded);
    };

    const handleDismiss = () => {
        closeSnackbar(props.id);
    };

    return (
        <Card >
            hi
        </Card>
    );
};

// export const withUserSnackbar = Component => {
//     return props => {

//         const { enqueueSnackbar } = useSnackbar();

//         return <Component enqueueSnackbar={enqueueSnackbar} {...props}></Component>;
//     }
// }

// https://iamhosseindhv.com/notistack/demos#action-for-all-snackbars
// https://github.com/iamhosseindhv/notistack#documentation

const defaultOptions = {
    anchorOrigin: {
        vertical: 'top',
        horizontal: 'right'
    }
}

// class SnackB extends React.Component{

//     constructor(props){
//         super(props)
//     }
//     render(){
//         return(
//             <p>{this.props.snackMessage}</p>
//         )
//     }
// }

function SnackB(props) {
    return (
        <p>greetings</p>
    )
}



class LayoutSnackbar extends React.Component {

    state = {
        isOpen: true,
        vertical: 'top',
        horizontal: 'right'
    }

    handleClick = () => {
        const key = this.props.enqueueSnackbar('nu22ll', {
            ...defaultOptions,
            content: (key, message) => {
                console.log(new SnackB())
                return <SnackB key={key} snackMessage={message} />
            }
        })
    }

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


