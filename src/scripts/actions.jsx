var $ = require("jquery"),
    constants = require("./constants");

module.exports = {
  changeCountry: function(country) {
    this.dispatch(constants.CHANGE_COUNTRY, country);
  },
  loadBeverages: function() {
    this.dispatch(constants.LOAD_BEVERAGES);
    var jqxhr = $.ajax({
        url: "/beverages.json",
        context: this
      })
      .done(function(response) {
        this.dispatch(constants.LOAD_BEVERAGES_SUCCESS, response);
      })
      .fail(function(response) {
        this.dispatch(constants.LOAD_BEVERAGES_FAIL, response);
      });
  },
  toggleDetail: function(beverage) {
    this.dispatch(constants.TOGGLE_DETAIL, beverage);
  }

};
