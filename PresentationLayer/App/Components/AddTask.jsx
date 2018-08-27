import React, { Component } from 'react';

export default class AddTask extends Component {

    state = { typed: '' }

    render() {
        return (
            <div className="list-control">
                <textarea ref="field" required="required" placeholder="Write new task" onChange={this.handleTyping}></textarea>
                <button className="list-button" onClick={this.addTask}>Create</button>
                <button className="list-button" onClick={this.props.cancel}>Cancel</button>
            </div>
        );
    }

    addTask = () => {
        var text = this.state.typed;
        text = text.replace(/\s{2,}/g, ' ').replace(/^\s+|>|</g, '');
        if (text.length > 0) {
            this.props.addTask(text);
            this.refs.field.value = '';
            this.setState({ typed: '' });
        }
    }

    handleTyping = (event) => this.setState({ typed: event.target.value });
}