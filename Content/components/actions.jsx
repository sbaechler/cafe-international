var $ = require("jquery"),
    constants = require("../constants");

module.exports = {
  changeCountry: function(country) {
    this.dispatch(constants.CHANGE_COUNTRY, country);
  },
  loadBeverages: function() {
    this.dispatch(constants.LOAD_BEVERAGES);
    var jqxhr = $.ajax({
        url: "/api/Beverages",
        context: this
      })
      .done(function(response) {
        this.dispatch(constants.LOAD_BEVERAGES_SUCCESS, response);
      })
      .fail(function(response) {
        this.dispatch(constants.LOAD_BEVERAGES_FAIL, response);
      });
  }

};
