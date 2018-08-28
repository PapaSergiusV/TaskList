import React, { Component } from 'react';
import Task from './Task.jsx';
import AddTask from './AddTask.jsx';

export default class List extends Component {

    state = { isEdited: false, name: this.props.list.key, tasks: this.props.list.value }

    render() {
        var tasks = this.state.tasks.map(x => <Task key={x.id} task={x} delete={this.deleteTask} />);
        var bottom = (this.state.isEdited ?
            <AddTask cancel={this.writeTask} addTask={this.addTask} /> :
            <div className="list-control">
                <button className="list-button" onClick={this.writeTask}>+ New task</button>
                <button className="list-button">Delete list</button>
            </div> );
        return (
            <div className="list">
                <h2 className="h2">{this.state.name}</h2>
                {tasks}
                {bottom}
            </div>
        );
    }

    writeTask = () => {
        var res = !this.state.isEdited;
        this.setState({ isEdited: res });
    }

    addTask = (newText) => {
        var xhr = new XMLHttpRequest();
        var body = 'text=' + encodeURIComponent(newText) + '&idOfList=' + encodeURIComponent('1');
        xhr.open("POST", "/Tasks/CreateTaskInList", true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.onreadystatechange = () => {
            if (xhr.readyState == 4 && xhr.status == 200) {
                var newTasks = this.state.tasks;
                var newId = parseInt(xhr.responseText, 10);
                newTasks.push({ id: newId, text: newText, isDone: false });
                this.setState({ tasks: newTasks });
                this.writeTask();
            }
        }

        xhr.send(body);
    }

    deleteTask = (id) => {
        var xhr = new XMLHttpRequest();
        var body = 'id=' + encodeURIComponent(id) + '&idOfList=' + encodeURIComponent('1');
        xhr.open("POST", "/Tasks/DelTask", true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.onreadystatechange = () => {
            if (xhr.readyState == 4 && xhr.status == 200) {
                console.log(xhr.responseText);
                id = parseInt(id);
                var res = this.state.tasks.filter(x => x.id != id);
                this.setState({ tasks: res });
            }
        }

        xhr.send(body);
    }
}