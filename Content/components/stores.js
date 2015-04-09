var Fluxxor = require("fluxxor"),
  constants = require("../constants");


var BeverageStore = Fluxxor.createStore({
	initialize: function() {
		this.loading = false;
		this.error = null;
		this.beverages = [];

		this.bindActions(
      constants.LOAD_BEVERAGES, this.onLoadBeverages,
      constants.LOAD_BEVERAGES_SUCCESS, this.onLoadBeveragesSuccess,
      constants.LOAD_BEVERAGES_FAIL, this.onLoadBeveragesFail
	  );
	},

  getState: function() {
    return {
      loading: this.loading,
      error: this.error,
      beverages: this.beverages
    }
  },

  onLoadBeverages: function() {
    this.loading = true;
    this.emit("change");
  },

  onLoadBeveragesSuccess: function(payload) {
    this.loading = false;
    this.error = null;

    // create a new array where the BeverageID is the array index.
    this.beverages = payload.reduce(function(acc, beverage) {
      acc[beverage.BeverageID] = beverage;
      return acc;
    }, {});
    this.emit("change");
  },

  onLoadBeveragesFail: function(payload) {
    this.loading = false;
    this.error = payload.error;
    this.emit("change");
  }
});

var CountryStore = Fluxxor.createStore({
  initialize: function() {
    this.countries = window.countries.reduce(function(acc, country) {
      acc[country.ISO2] = country;
      return acc;
    }, {});
    this.country = window.userCountry || window.countries[0].ISO2;

    this.bindActions(
      constants.CHANGE_COUNTRY, this.onChangeCountry
    );
  },

  getState: function() {
    return {
      country: this.country,
      countries: this.countries
    }
  },

  onChangeCountry: function(country) {
    this.country = country;
    this.emit("change");
  }

});



module.exports = {
  BeverageStore: BeverageStore,
  CountryStore: CountryStore
};
