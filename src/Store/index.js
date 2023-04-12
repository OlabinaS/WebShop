import { createStore } from 'redux';
import { combineReducers } from 'redux';
import productsReducer from './Products';


const rootReducer = combineReducers({
  products: productsReducer,
//   todo: todoReducer,
});

// Create the store with the reducer
export const store = createStore(rootReducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());


