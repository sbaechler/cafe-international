var React = require("react"),
    mixins = require("./mixins"),
    TextSelect = require("react-textselect"),
    _ = require("lodash");

/**
 * Country selector dropdown.
 * @param {object} countries - The list of countries
 * @param {String} country - The currently active country ID.
 */
var CountrySelect = React.createClass ({
  mixins: [mixins.FluxMixin],

  handleCountryChange: function(value) {
    debugger
    if(value !== undefined) {
      this.getFlux().actions.changeCountry(value);
    }
  },

  render: function() {
    var countries = _.map(this.props.countries, function(c) {
                      return c.Name;
                    }),
        country = countries.indexOf(this.props.countries[this.props.country].Name);
        return(
        <TextSelect options={countries}
                  onChange={this.handleCountryChange}
                  active={country} />
    );
  }

});

module.exports = CountrySelect;
