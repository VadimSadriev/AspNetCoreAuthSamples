import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import App from './App';
import { createBrowserHistory } from 'history';
import configureStore from './store';
import { ConnectedRouter } from 'connected-react-router'
import { SnackbarProvider } from 'notistack';

const history = createBrowserHistory({ basename: '/' });

const initialState = {};

const store = configureStore(history, initialState);

ReactDOM.render(
    <Provider store={store}>
        <ConnectedRouter history={history}>
            <SnackbarProvider maxSnack={10}>
                <App />
            </SnackbarProvider>
        </ConnectedRouter>
    </Provider>
    , document.getElementById('root'));