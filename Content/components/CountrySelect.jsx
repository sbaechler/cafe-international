var React = require("react"),
    mixins = require("./mixins"),
    Dropdown = require("babel!react-dropdown"),
    _ = require("lodash");

/**
 * Country selector dropdown.
 * @param {object} countries - The list of countries
 * @param {String} country - The currently active country ID.
 * @param {function} onChange - The onChange handler function.
 */
var CountrySelect = React.createClass ({
  mixins: [mixins.FluxMixin],

  handleCountryChange: function(option) {
    this.getFlux().actions.changeCountry(option.value);
  },

  render: function() {
    var countries = _.map(this.props.countries, function(c) {
                      return {value: c.ISO2, label: c.Name};
                    }),
        defaultOption = {value: this.props.country, label:countries[this.props.country]};

    return(
        <Dropdown options={countries}
                  onChange={this.handleCountryChange}
                  value={defaultOption} />
    );
  }

});

module.exports = CountrySelect;
