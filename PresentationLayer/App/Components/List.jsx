import React, { Component } from 'react';
import Task from './Task.jsx';
import AddTask from './AddTask.jsx';
import ListName from './ListName.jsx';

export default class List extends Component {

    state = {
        isEdited: false,
        tasks: this.props.list.value,
        minimized: false
    }

    render() {
        var tasks = this.state.minimized ? null : this.state.tasks.map(x => <Task key={x.id} task={x} delete={this.deleteTask} />);
        var bottom = this.state.isEdited ?
            <AddTask cancel={this.writeTask} addTask={this.addTask} /> :
            <div className="list-control">
                <button className="list-button" onClick={this.writeTask}>+ New task</button>
                <button className="list-button">Delete list</button>
            </div>;
        return (
            <div className="list">
                <ListName name={this.props.list.key} />
                <div className="minimize" onClick={this.minimize}><i className="fas fa-window-minimize"></i></div>
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
                var obj = { item1: 0, item2: "" };
                obj = JSON.parse(xhr.responseText);
                var newTasks = this.state.tasks;
                newTasks.push({ id: obj.item1, text: newText, isDone: false, time: obj.item2 });
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
                if (xhr.responseText == 'true') {
                    id = parseInt(id);
                    var res = this.state.tasks.filter(x => x.id != id);
                    this.setState({ tasks: res });
                }
            }
        }

        xhr.send(body);
    }

    minimize = () => this.setState({ minimized: !this.state.minimized });
}