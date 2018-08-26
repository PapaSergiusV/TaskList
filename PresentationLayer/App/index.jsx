import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import App from './Components/Main.jsx'

var xhr = new XMLHttpRequest();
var body = 'id=' + encodeURIComponent('1');
xhr.open("POST", "/Tasks/GetTasksOfList", true);
xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
var list = [];
xhr.onreadystatechange = (function () {
    if (xhr.readyState == 4 && xhr.status == 200) {
        list = JSON.parse(xhr.responseText);
        ReactDOM.render(<App list={list}/>, document.getElementById('root'));
    }
});
xhr.send(body);