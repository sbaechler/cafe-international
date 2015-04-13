var React = require("react"),
    _ = require("lodash");

/**
 * Country selector dropdown.
 * @param {object} countries - The list of countries
 * @param {String} country - The currently active country ID.
 * @param {function} onChange - The onChange handler function.
 */
var CountrySelect = React.createClass ({

  render: function() {
    return(
      <select value={this.props.country} onChange={this.props.onChange}>
        {_.map(this.props.countries, function(country, iso){
          return <option value={iso}>{country.Name}</option>;
        })}
      </select>
    )
  }

});

module.exports = CountrySelect;
