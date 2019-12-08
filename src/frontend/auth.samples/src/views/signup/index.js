import React from 'react';
import * as actions from '../../store/actions/signup';
import { connect } from 'react-redux';
import {
    Container,
    Card,
    CardHeader,
    CardContent,
    CardActions,
    Button,
    TextField
} from '@material-ui/core';
import './style.scss';

class Signup extends React.Component {

    state = {
        userName: '',
        email: '',
        password: ''
    }

    onUserNameChanged = e => {
        this.setState({
            userName: e.target.value
        })
    }

    onEmailChanged = e => {
        this.setState({
            email: e.target.value
        })
    }

    onPasswordChanged = e => {
        this.setState({
            password: e.target.value
        })
    }

    render() {

        return (
            <div>
                <Container maxWidth='sm'>
                   <Card>
                       <CardHeader className='card-header' title='Register account' />
                       <CardContent className='card-content'>
                            <TextField label='User Name' color='secondary' onChange={this.onUserNameChanged}/>
                            <TextField label='Email' color='secondary' onChange={this.onEmailChanged}/>
                            <TextField label='Password' type='password' color='secondary' onChange={this.onPasswordChanged}/>
                       </CardContent>
                       <CardActions className='card-footer'>
                          <Button variant="contained" color="primary" >Sign Up</Button>
                       </CardActions>
                   </Card>
                </Container>
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        apiMessage: state.signup.message
    }
}

const mapDispatchToProps = dispatch => {
    return {
        signup: (userName, email, password) => {
            dispatch(actions.signup(userName, email, password));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Signup);