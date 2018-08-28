import React, { Component } from 'react';

export default class AddTask extends Component {

    state = { typed: '' }

    render() {
        return (
            <div className="list-control">
                <textarea required="required" placeholder="Write new task" onChange={this.handleTyping}>{this.state.typed}</textarea>
                <button className="list-button" ref="createButton" onClick={this.addTask}>Create</button>
                <button className="list-button" onClick={this.props.cancel}>Cancel</button>
            </div>
        );
    }

    addTask = () => {
        var text = this.state.typed;
        text = text.replace(/\s{2,}/g, ' ').replace(/^\s+|>|</g, '');
        if (text.length > 0) {
            this.refs.createButton.innerHTML = '<i class="fas fa-spinner"></i>';
            this.props.addTask(text);
        }
    }

    handleTyping = (event) => this.setState({ typed: event.target.value });
}