var Fluxxor = require("fluxxor"),
  constants = require("../constants");


var DetailStore = Fluxxor.createStore({
	initialize: function() {
		this.beverage = undefined;
    this.language = navigator.language || navigator.userLanguage;
    this.isVisible = false;

		this.bindActions(
      constants.TOGGLE_DETAIL, this.onToggleDetail,
      constants.CHANGE_COUNTRY, this.onChangeCountry
	  );
	},

  getState: function() {
    return {
      beverage: this.beverage,
      language: this.language,
      isVisible: this.isVisible
    }
  },

  onChangeCountry: function(country) {
    if(this.isVisible) {
      this.isVisible = false;
      this.emit("change");
    }
  },

  onToggleDetail: function(beverage) {
    if (beverage !== undefined && beverage.ID) {
      this.beverage = beverage;
      this.isVisible = true;
    } else {
      this.isVisible = false;
    }
    this.emit("change");
  }

});

module.exports = DetailStore;
