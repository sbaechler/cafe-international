var Fluxxor = require("fluxxor"),
  constants = require("../constants");


var BeverageStore = Fluxxor.createStore({
	initialize: function() {
		this.loading = false;
		this.error = null;
		this.beverages = {};
    // create a new object where the CupID is the key.
    this.cups = [];
    _.forEach(window.cups, function(cup) {
      this.cups[cup.ID] = cup;
    });

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
      beverages: this.beverages,
      cups: this.cups
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
    this.beverages = payload.reduce(function(acc, beverage) {
      beverage.cup = this.cups[beverage.CupID];
      acc[beverage.ID] = beverage;
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
    this.country = window.userCountry || 'AT';

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
