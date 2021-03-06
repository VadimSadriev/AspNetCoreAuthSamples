import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import Home from './views/home';
import SignUp from './views/signup';
import Signin from './views/signin';
import NotFound from './components/notFound';
import { isAuthorized } from './shared/utils/auth';

export default class Routers extends React.Component {

    render() {
        return (
            <Switch>
                <Route exact path='/' render={() => <Home title="Auth Samples - Home" />}/>
                <Route path='/signup' render={() => <SignUp title="Auth Samples - Signup" />} />
                <Route path='/signin' render={() => <Signin title="Auth Samples - Signin" />}/>
                <Route component={NotFound}/>
            </Switch>
        );
    }
}

function AuthRoute({ component: Component, ...props}){

    if (isAuthorized()){
        return (
            <Route {...props} render={() => <Component title={props.title} />} />
        )
    }
    
    return <Redirect to={{
        pathname: '/signin',
        state: { from: props.location }
        }}
      />
}