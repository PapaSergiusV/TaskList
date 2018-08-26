import React, { Component } from 'react';

export default class Main extends Component {
    render() {
        var list = this.props.list.map(x => <div key={x.id}>{x.isDone? "+ " : "-  "}{x.text}</div>);
        return (<div>{list}</div>);
    }
}