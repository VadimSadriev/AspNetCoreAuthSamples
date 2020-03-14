import React, { useEffect, useCallback, useState } from 'react';
import * as actions from '../../store/actions/signin';
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

function Signin(props){

    useEffect(() => {
        document.title = props.title;
    })

    const [userName, setUserName] = useState('');

    const [email, setEmail] = useState('');

    const [password, setPassword] = useState('');

    const onSignin = (e) => {
        props.signin(userName, email, password);
    }
    
    return (
        <React.Fragment>
                <Container maxWidth='sm'>
                    <Card>
                        <CardHeader className='card-header' title='Signin with user name or email' />
                        <CardContent className='card-content'>
                            <TextField label='User Name' onChange={e => setUserName(e.target.value)}/>
                            <TextField label='Email' onChange={e => setEmail(e.target.value)}/>
                            <TextField label='Password' type='password' onChange={e => setPassword(e.target.value)}/>
                        </CardContent>
                        <CardActions className='card-footer'>
                            <Button variant="contained" color="primary" onClick={onSignin}>Signin</Button>
                        </CardActions>
                    </Card>
                </Container>
        </React.Fragment>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        signin: (userName, email, password) => {
            dispatch(actions.signin(userName, email, password));
        }
    }
}

export default connect(null, mapDispatchToProps)(Signin);