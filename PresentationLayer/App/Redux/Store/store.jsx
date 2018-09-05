import { createStore, applyMiddleware } from 'redux';
import reducer from '../Reducers/index.jsx';
import getListsMiddleware from '../Middlewares/getListsMiddleware.jsx';

var midds = applyMiddleware(getListsMiddleware);
var store = createStore(reducer, {}, midds);

//dev
window.store = store;

export default store;