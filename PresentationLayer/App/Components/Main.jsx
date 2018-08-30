import React, { Component } from 'react';
import List from './List.jsx';
import Navbar from './Navbar.jsx';

export default class Main extends Component {
    render() {
        return (
            <div className="container-fluid">
                <Navbar />
                <div className="row">
                    <div className="col-lg-3 col-md-4 col-sm-6">
                        <List list={this.props.list} />
                    </div>
                </div>
            </div>
        );
    }
}