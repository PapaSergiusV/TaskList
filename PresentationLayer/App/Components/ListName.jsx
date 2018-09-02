import React, { Component } from 'react';

export default class ListName extends Component {

    state = { name: this.props.name, typed: this.props.name, renameMode: false }

    render() {
        var title = this.state.renameMode ?
            <div className="rename-list">
                <input className="rename-list" value={this.state.typed} onChange={this.handleTyping}></input>
                <button className="rename-list" ref="saveButton" onClick={this.rename}>Save</button>
            </div> :
            this.state.name;
        return <h2 className="h2" onDoubleClick={this.rename} >{title}</h2>;
    }

    rename = () => {
        if (!this.state.renameMode)
            this.setState({ renameMode: true });
        else {
            var text = this.state.typed.replace(/\s{2,}/g, ' ').replace(/^\s+|>|</g, '');
            if (text.length > 0) {
                this.refs.saveButton.innerHTML = '<i class="fas fa-spinner"></i>';
                // Server
                var xhr = new XMLHttpRequest();
                var body = 'name=' + encodeURIComponent(text) + '&idOfList=' + encodeURIComponent('1');
                xhr.open("POST", "/Tasks/RenameList", true);
                xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

                xhr.onreadystatechange = () => {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        if (xhr.responseText == 'true')
                            this.setState({ typed: text, name: text, renameMode: false });
                        else
                            this.setState({ renameMode: false });
                    }
                    else
                        this.setState({ renameMode: false });
                }

                xhr.send(body);
            }
        }
    }

    handleTyping = (ev) => {
        if (ev.target.value.length <= 15)
            this.setState({ typed: ev.target.value });
    }


}