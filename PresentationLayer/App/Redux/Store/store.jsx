import { createStore } from 'redux';
import reducer from '../Reducers/index.jsx';

var store = createStore(reducer);

//dev
window.store = store;

export default store;