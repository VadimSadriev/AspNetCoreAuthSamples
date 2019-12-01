import React from 'react';
import {
    Container,
    Card,
    CardHeader,
    CardContent,
    CardActions,
    Button
} from '@material-ui/core';
import './style.scss';

class Register extends React.Component {

    render() {
        return (
            <div>
                <Container maxWidth='sm'>
                   <Card>
                       <CardHeader className='card-header' title='Register account' />
                       <CardContent className='card-content'>
                          This is some Content text
                       </CardContent>
                       <CardActions className='card-footer'>
                          <Button className='primary-button'>Register</Button>
                       </CardActions>
                   </Card>
                </Container>
            </div>
        )
    }
}

export default Register;