var React = require("react"),
		_ = require("lodash"),
		mixins = require("./mixins"),
		BeverageList = require("./BeverageList"),
		CountrySelect = require("./CountrySelect");

/**
 * The main Application entry point.
 * @param {object} flux - the Fluxxor instance.
 */
var Application = React.createClass({
	mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("coffeeStore")],

	getInitialState: function(){
		return {};
	},

	// Required by StoreWatchMixin
	getStateFromFlux: function() {
		return this.getFlux().store("coffeeStore").getState();
	},

	componentDidMount: function() {
		this.getFlux().actions.loadBeverages();
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

			<h1>Coffees in {this.state.countries[this.state.country].Name}</h1>


			{this.state.error ? "Error loading data" : null}
			{this.state.loading ? <p>Loading...</p> : null}
		  <BeverageList beverages={beverages} country={this.state.country} />
			<p className="suggest"><a href='mailt&#111;&#58;&#98;a%65&#99;h%73&#105;m&#64;st&#117;d%&#54;&#53;nts&#46;%7&#65;ha%77&#46;c&#37;&#54;&#56;'>Suggest a beverage</a></p>
		</div>
	  )
	}

});

module.exports = Application;
