var Fluxxor = require("fluxxor"),
  constants = require("../constants");


var CoffeeStore = Fluxxor.createStore({
	initialize: function() {
		this.loading = false;
		this.error = null;
		this.beverages = {};

    this.countries = window.countries.reduce(function(acc, country) {
      country.beverages = new Set();  // ES6 but already supported.
      acc[country.ISO2] = country;
      return acc;
    }, {});
    this.country = window.userCountry || 'CH';

    // create a new object where the CupID is the key.
    this.cups = {};
    _.forEach(window.cups, function(cup) {
      this.cups[cup.ID] = cup;
    }, this);

		this.bindActions(
      constants.LOAD_BEVERAGES, this.onLoadBeverages,
      constants.LOAD_BEVERAGES_SUCCESS, this.onLoadBeveragesSuccess,
      constants.LOAD_BEVERAGES_FAIL, this.onLoadBeveragesFail,
      constants.CHANGE_COUNTRY, this.onChangeCountry
	  );
	},

  getState: function() {
    return {
      loading: this.loading,
      error: this.error,
      beverages: this.beverages,
      cups: this.cups,
      country: this.country,
      countries: this.countries
    }
  },

  onLoadBeverages: function() {
    this.loading = true;
    this.emit("change");
  },

  onLoadBeveragesSuccess: function(payload) {
    this.loading = false;
    this.error = null;

    // create a new object where the BeverageID is the key.
    this.beverages = {};
    _.forEach(payload, function(beverage) {
      beverage.cup = this.cups[beverage.CupID];
      _.forEach(beverage.Countries, function(country) {
        this.countries[country.CountryISO2].beverages.add(country.BeverageID);
      }, this);
      this.beverages[beverage.ID] = beverage;
    }, this);
    this.emit("change");
  },

  onLoadBeveragesFail: function(payload) {
    this.loading = false;
    this.error = payload.error;
    this.emit("change");
  },

  onChangeCountry: function(country) {
    this.country = country;
    this.emit("change");
  }
});

module.exports = CoffeeStore;
