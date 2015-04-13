var React = require("react"),
		_ = require("lodash"),
		mixins = require("./mixins"),
		BeverageList = require("./BeverageList"),
		CountrySelect = require("./CountrySelect");

var Application = React.createClass({
	mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("coffeeStore")],

	getInitialState: function(){
		return {
			language : "de-ch"
		};
	},

	// Required by StoreWatchMixin
	getStateFromFlux: function() {
		return this.getFlux().store("coffeeStore").getState();
	},

	componentDidMount: function() {
		this.getFlux().actions.loadBeverages();
	},

	handleCountryChange: function(event) {
		this.getFlux().actions.changeCountry(event.target.value);
	},

	render: function() {
	  return(
		<div>

			<CountrySelect
				countries={this.state.countries}
				country={this.state.country}
				onChange={this.handleCountryChange}
			/>

		  <h1>All Beverages</h1>
		  {this.state.error ? "Error loading data" : null}
			{this.state.loading ? <p>Loading...</p> : null}
		  <BeverageList beverages={this.state.beverages} />
		</div>
	  )
	}

});

module.exports = Application;
