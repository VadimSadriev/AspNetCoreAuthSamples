import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Home from './views/home';
import SignUp from './views/signup';

export default class Routers extends React.Component {

    render() {
        return (
            <Switch>
                <Route exact path='/' component={Home}></Route>
                <Route path='/signup' component={SignUp}></Route>
            </Switch>
        );
    }
}