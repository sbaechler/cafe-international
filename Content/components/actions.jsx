var constants = require("../constants");

module.exports = {
  changeCountry: function() {
    this.dispatch(constants.CHANGE_COUNTRY);
  }
};
