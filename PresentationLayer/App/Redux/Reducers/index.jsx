﻿import { combineReducers } from 'redux';
import listReducer from './listReducer.jsx';

export default combineReducers({
    lists: listReducer
});