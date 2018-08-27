import React, { Component } from 'react';

export default class Task extends Component {

    state = { isDone: this.props.task.isDone }

    render() {
        var cellTextClass = this.state.isDone ? "cell-text cell-text-done" : "cell-text";
        return (
            <div className="cell">
                <div className={cellTextClass} >
                    {this.props.task.text}
                </div>
                <div className="cell-buttons">
                    <i className="fas fa-check" onClick={this.taskIsDone}></i>
                    <i className="far fa-trash-alt"></i>
                </div>
            </div>    
        );
    }

    taskIsDone = () => {
        var res = !this.state.isDone;
        this.setState({ isDone: res });
    }
}