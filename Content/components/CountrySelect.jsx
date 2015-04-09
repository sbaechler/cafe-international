var React = require("react"),
    Fluxxor = require("fluxxor"),
    _ = require("lodash");

var FluxMixin = Fluxxor.FluxMixin(React),
	StoreWatchMixin = Fluxxor.StoreWatchMixin;


var CountrySelect = React.createClass ({
  mixins: [FluxMixin, StoreWatchMixin("CountryStore")],

  getInitialState: function() {
    return {};
  },

  // Required by StoreWatchMixin
  getStateFromFlux: function() {
    return this.getFlux().store("CountryStore").getState();
  },

  handleChange: function(event) {
    this.getFlux().actions.changeCountry(event.target.value);
  },

  render: function() {
    return(
      <select value={this.state.country} onChange={this.handleChange}>
        {_.map(this.state.countries, function(country, iso){
          return <option value={iso}>{country.Name}</option>;
        })}
      </select>
    )
  }

});

module.exports = CountrySelect;
