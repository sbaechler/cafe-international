// Code for the client side.
require("./css/main.scss");
require("./css/select.less");

var Application = require("./components/Application");
var React = require("react"),
	Fluxxor = require("fluxxor"),
	constants = require("./constants"),
	CoffeeStore = require("./components/CoffeeStore"),
  DetailStore = require("./components/DetailStore"),
	actions = require("./components/actions");

var stores = {
	coffeeStore : new CoffeeStore(),
	detailStore: new DetailStore()
};

var flux = new Fluxxor.Flux(stores, actions);


flux.on("dispatch", function(type, payload) {
	console.log("dispatch", type, payload);
});


React.render(
  <Application flux={flux} />,
  document.getElementById("content")
);
