// Code for the client side.
var Components = require('./components');
var React = require('react');

React.render(
  <Components.CommentBox />,
  document.getElementById('content')
);
