import React, { Component } from 'react';

export default class Task extends Component {

    state = { isDone: this.props.task.isDone, deleted: false }

    render() {
        var cellTextClass = this.state.isDone ? "cell-text cell-text-done" : "cell-text";
        return (
            <div className="cell">
                <div className={cellTextClass} >
                    {this.props.task.text}
                </div>
                <div className="cell-buttons">
                    <i className="fas fa-check" onClick={this.taskIsDone}></i>
                    <i ref="delButton" className="far fa-trash-alt" onClick={this.delete}></i>
                </div>
            </div>    
        );
    }

    taskIsDone = () => {
        var res = !this.state.isDone;
        this.setState({ isDone: res });
    }

    delete = () => {
        if (!this.state.deleted) {
            this.setState({ deleted: true });
            this.refs.delButton.className = "fas fa-spinner";
            this.props.delete(this.props.task.id);
        }
    }
}