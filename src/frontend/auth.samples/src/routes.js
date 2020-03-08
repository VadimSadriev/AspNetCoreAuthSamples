import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Home from './views/home';
import SignUp from './views/signup';

export default class Routers extends React.Component {

    render() {
        return (
            <Switch>
                <Route exact path='/' render={() => <Home title="Auth Samples - Home" />}/>
                <Route path='/signup' render={() => <SignUp title="Auth Samples - Signup" />} />
            </Switch>
        );
    }
}