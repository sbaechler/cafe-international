var React = require("react"),
		_ = require("lodash"),
		mixins = require("./mixins"),
		BeverageList = require("./BeverageList"),
		CountrySelect = require("./CountrySelect");

var Application = React.createClass({
	mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("BeverageStore")],

	getInitialState: function(){
		return {
			language : "de-ch"
		};
	},

	// Required by StoreWatchMixin
	getStateFromFlux: function() {
		return this.getFlux().store("BeverageStore").getState();
	},

	componentDidMount: function() {
		this.getFlux().actions.loadBeverages();
	},

	render: function() {
	  return(
		<div>

			<CountrySelect flux={this.props.flux} />

		  <h1>All Beverages</h1>
		  {this.state.error ? "Error loading data" : null}
			{this.state.loading ? <p>Loading...</p> : null}
		  <BeverageList flux={this.props.flux} />
		</div>
	  )
	}

});

module.exports = Application;
