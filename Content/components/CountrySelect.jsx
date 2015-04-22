var React = require("react"),
    mixins = require("./mixins"),
    Select = require("react-select"),
    _ = require("lodash");

/**
 * Country selector dropdown.
 * @param {object} countries - The list of countries
 * @param {String} country - The currently active country ID.
 */
var CountrySelect = React.createClass ({
  mixins: [mixins.FluxMixin],

  handleCountryChange: function(value) {
    if(value !== undefined) {
      this.getFlux().actions.changeCountry(value);
    }
  },

  render: function() {
    var countries = _.map(this.props.countries, function(c) {
                      return {value: c.ISO2, label: c.Name };
                    });
    return(
        <Select options={countries}
                  onChange={this.handleCountryChange}
                  value={this.props.country} />
    );
  }

});

module.exports = CountrySelect;
