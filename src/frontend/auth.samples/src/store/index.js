import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';


export default function configureStore (history, initialState) {
  const reducers = {
    
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
