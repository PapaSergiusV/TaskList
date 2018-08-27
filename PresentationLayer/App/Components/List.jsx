import React, { Component } from 'react';
import Task from './Task.jsx';

export default class List extends Component {

    state = { isEdited: false }

    render() {
        var tasks = this.props.list.value.map(x => <Task key={x.id} task={x} />);
        var bottom = (this.state.isEdited ?
            <div>edited</div> :
            <div className="list-control">
                <button className="list-button" onClick={this.newTask}>+ New task</button>
                <button className="list-button">Delete list</button>
            </div> );
        return (
            <div className="list">
                <h2 className="h2">{this.props.list.key}</h2>
                {tasks}
                {bottom}
            </div>
        );
    }

    newTask = () => {
        var res = !this.state.isEdited;
        this.setState({ isEdited: res });
    }
}