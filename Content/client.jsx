// Code for the client side.
require("./css/main.scss");
var Application = require("./components/Application");
var React = require("react"),
	Fluxxor = require("fluxxor"),
	constants = require("./constants"),
	CoffeeStore = require("./components/CoffeeStore"),
	actions = require("./components/actions");

var stores = {
	coffeeStore : new CoffeeStore()
};

var flux = new Fluxxor.Flux(stores, actions);


flux.on("dispatch", function(type, payload) {
	console.log("dispatch", type, payload);
});


React.render(
  <Application flux={flux} />,
  document.getElementById("content")
);
