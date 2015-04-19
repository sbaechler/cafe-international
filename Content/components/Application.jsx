var React = require("react"),
		_ = require("lodash"),
		mixins = require("./mixins"),
		BeverageList = require("./BeverageList"),
		CountrySelect = require("./CountrySelect");

var Application = React.createClass({
	mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("coffeeStore")],

	getInitialState: function(){
		return {
			language : navigator.language || navigator.userLanguage
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
		var beverages = {};
		this.state.countries[this.state.country].beverages.forEach(function(beverageID){
			beverages[beverageID] = this.state.beverages[beverageID]
		}, this);

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
		  <BeverageList beverages={beverages} />
		</div>
	  )
	}

});

module.exports = Application;
