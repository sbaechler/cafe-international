var Fluxxor = require("fluxxor"),
React = require("react"),
_ = require("lodash"),
CountrySelect = require("./CountrySelect");


var FluxMixin = Fluxxor.FluxMixin(React),
	StoreWatchMixin = Fluxxor.StoreWatchMixin;

var Application = React.createClass({
	mixins: [FluxMixin, StoreWatchMixin("BeverageStore")],

	getInitialState: function(){
		return {
			language : "de-ch"
		};
	},

	// Required by StoreWatchMixin
	getStateFromFlux: function() {
		return this.getFlux().store("BeverageStore").getState();
	},

	render: function() {
	  var beverages = this.state.beverages.map(function(beverage){
			return <li>{beverage.Name}</li>;
	  });

	  return(
		<div>

			<CountrySelect flux={this.props.flux} />

		  <h1>All Beverages</h1>
		  {this.state.error ? "Error loading data" : null}
		  <ul>
		    {this.state.loading ? <li>Loading...</li> : null}
			  {beverages}
		  </ul>
		</div>
	  )
	}

});

module.exports = Application;
