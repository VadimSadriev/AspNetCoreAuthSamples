import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import signupReducer from './reducers/signup';
import layoutBackdropReducer from './reducers/layoutBackdrop';
import layoutSnackbarReducer from './reducers/layoutSnackbar';
import { connectRouter, routerMiddleware } from 'connected-react-router'

export default function configureStore(history, initialState) {
  const reducers = {
    signup: signupReducer,
    layoutBackdrop: layoutBackdropReducer,
    layoutSnackbar: layoutSnackbarReducer
  };

  const middlewares = [
    thunk,
    routerMiddleware(history)
  ];

  const enhancers = [];

  const rootReducer = combineReducers({
    ...reducers,
    router: connectRouter(history)
  });

  const composedEnhancers = compose(...enhancers)

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middlewares), composedEnhancers)
  );
}
