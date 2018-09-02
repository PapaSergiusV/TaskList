import React, { Component } from 'react';
import List from './List.jsx';
import Navbar from './Navbar.jsx';
import store from '../Redux/Store/store.jsx';
import { Provider } from 'react-redux';

export default class Main extends Component {
    render() {
        return (
            <div className="container-fluid">
                <Navbar />
                <div className="row">
                    <div className="col-lg-3 col-md-4 col-sm-6">
                        <Provider store={store}>
                            <List list={this.props.list} />
                        </Provider>
                    </div>
                </div>
            </div>
        );
    }
}