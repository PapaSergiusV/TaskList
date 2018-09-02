import { combineReducers } from 'redux';
import listReducer from './listReducer.jsx';

export default combineReducers({
    test: listReducer
});