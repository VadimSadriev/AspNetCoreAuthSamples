import React from 'react';

class LayoutSnackbar extends React.Component{

    render(){
        return(
            <React.Fragment>
                SnackBar
            </React.Fragment>
        )
    }
}

const mapStateToProps = state => {
    return {
        messages: state.layoutSnackbar.messages
    }
}

export default connect(mapStateToProps)(LayoutSnackbar);