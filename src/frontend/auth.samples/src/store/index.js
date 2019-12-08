import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import signupReducer from './reducers/signup';


export default function configureStore (history, initialState) {
  const reducers = {
    signup: signupReducer
  };

  const middlewares = [
    thunk,
    routerMiddleware(history)
  ];

  const enhancers = [];

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  const composedEnhancers = compose(...enhancers)

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middlewares), composedEnhancers)
  );
}
