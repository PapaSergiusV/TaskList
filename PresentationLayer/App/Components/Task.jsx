import React, { Component } from 'react';

export default class Task extends Component {

    state = { isDone: this.props.task.isDone, deleted: false }

    render() {
        var cellTextClass = this.state.isDone ? "cell-text cell-text-done" : "cell-text";
        return (
            <div className="cell">
                <div className={cellTextClass} >
                    {this.props.task.text}
                    <div className="task-time">{this.props.task.time}</div>
                </div>
                <div className="cell-buttons">
                    <i ref="checkButton" className="fas fa-check" onClick={this.taskIsDone}></i>
                    <i ref="delButton" className="far fa-trash-alt" onClick={this.delete}></i>
                </div>
            </div>    
        );
    }

    taskIsDone = () => {
        this.refs.checkButton.className = "fas fa-spinner";
        var res = !this.state.isDone;
        // Server
        var xhr = new XMLHttpRequest();
        var body = 'id=' + encodeURIComponent(this.props.task.id)
            + '&text=' + encodeURIComponent(this.props.task.text)
            + '&isDone=' + encodeURIComponent(res);
        xhr.open("POST", "/Tasks/TaskChangeStatus", true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.onreadystatechange = () => {
            if (xhr.readyState == 4 && xhr.status == 200) {
                if (xhr.responseText == 'true')
                    this.setState({ isDone: res });
            }
            this.refs.checkButton.className = "fas fa-check";
        }

        xhr.send(body);
    }

    delete = () => {
        if (!this.state.deleted) {
            this.setState({ deleted: true });
            this.refs.delButton.className = "fas fa-spinner";
            this.props.delete(this.props.task.id);
        }
    }
}