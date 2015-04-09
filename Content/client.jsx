// Code for the client side.
var Application = require('./components/Application');
var React = require('react'),
	Fluxxor = require("fluxxor"),
	constants = require("./constants"),
	Stores = require("./components/stores"),
	actions = require("./components/actions");

var stores = {
	BeverageStore : new Stores.BeverageStore(),
	CountryStore: new Stores.CountryStore()
};

var flux = new Fluxxor.Flux(stores, actions);


flux.on("dispatch", function(type, payload) {
	console.log("dispatch", type, payload);
});


React.render(
  <Application flux={flux} />,
  document.getElementById('content')
);
