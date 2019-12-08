import React from 'react';
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

class Register extends React.Component {

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

export default Register;