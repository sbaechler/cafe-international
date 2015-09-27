/**
 * @jsx React.DOM
 * Unit tests for the BeverageList and Beverage components.
 */
jest.dontMock('../Beverage.jsx');
jest.dontMock('fluxxor');
jest.dontMock('fluxxor-test-utils');
jest.dontMock('util'); // Jest Issue #106


describe('Espressos', function(){
  var React = require("react/addons");
  var FluxxorTestUtils = require('fluxxor-test-utils');

  var fakeFlux = FluxxorTestUtils.fakeFlux();

  var Beverage = require('../Beverage.jsx');
  var TestUtils = React.addons.TestUtils;

  var beverage = {"Countries":[{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"de-ch"},{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"fr-ch"}],"Ingredients":[{"Ingredient":{"ID":1,"Name":"espresso","Slug":"espresso"},"Position":1,"AmountMl":30,"AmountOz":1}],"ID":2,"Name":"Espresso","Slug":"espresso","Strength":8,"Comment":null,"CupID":1,
    cup: {"ID":1,"Name":"Demitasse","Slug":"demitasse","SizeMl":90,"LUT":"[[20, 29, 1.45], [30, 43, 1.4], [60, 78, 1.16],[90, 104, 0.866]]"}};

  //  Render a Beverage
  var espresso = TestUtils.renderIntoDocument(
      <Beverage beverage={beverage} country="CH" flux={fakeFlux} />
  );

  it('can make a simple espresso', function() {
    // check the fill function for a single ingredient
    var ingredientHeight = espresso.getIngredientHeight();
    var heights = ingredientHeight(30);
    expect(heights).toEqual([0, 43]);
  });

  it('can calculate the fill function for multiple ingredients at known levels', function() {
    var ingredientHeight = espresso.getIngredientHeight();
    var heights = ingredientHeight(20);
    expect(heights).toEqual([0, 29]);
    heights = ingredientHeight(10);
    expect(heights).toEqual([29, 43]);
    heights = ingredientHeight(30);
    expect(heights).toEqual([43, 78]);
    heights = ingredientHeight(30);
    expect(heights).toEqual([78, 104]);
  });

  it('can calculate the fill function for multiple ingredients at unknown levels.', function(){
    var ingredientHeight = espresso.getIngredientHeight();
    var heights = ingredientHeight(0);
    expect(heights).toEqual([0, 0]);

    //                    0,  10,   20, 30, 40,   50,   60, 70,    80,    90
    var expectedHeights = [0, 14.5, 29, 43, 54.6, 66.2, 78, 86.66, 95.32, 104];
    for(var i=0; i<(expectedHeights.length-1); i++) {
      heights = ingredientHeight(10);
      expect(heights).toEqual([expectedHeights[i], expectedHeights[i+1]]);
    }

  });

  it('can calculate the fill function for multiple ingredients and go past a data point', function(){
    var ingredientHeight = espresso.getIngredientHeight();
    var heights = ingredientHeight(10);
    expect(heights).toEqual([0, 14.5]);
    heights = ingredientHeight(40);
    expect(heights).toEqual([14.5, 66.2]);
  });

});

describe('Cappucino', function() {
  var React = require("react/addons");
  var Beverage = require('../Beverage.jsx');
  var TestUtils = React.addons.TestUtils;
  var beverage = {"Countries":[{"BeverageID":7,"CountryISO2":"CH","Popularity":3,"Name":"Cappucino","Language":"de-ch"},{"BeverageID":7,"CountryISO2":"CH","Popularity":3,"Name":"Cappucino","Language":"fr-ch"}], "Ingredients":[{"Ingredient":{"ID":1,"Name":"espresso","Slug":"espresso"},"Position":1,"AmountMl":60,"AmountOz":2},{"Ingredient":{"ID":4,"Name":"steamed milk","Slug":"steamed-milk"},"Position":2,"AmountMl":60,"AmountOz":2},{"Ingredient":{"ID":7,"Name":"milk foam","Slug":"milk-foam"},"Position":3,"AmountMl":60,"AmountOz":2}],"ID":7,"Name":"Cappucino","Slug":"cappucino","Strength":null,"Comment":null,"CupID":3,
      cup: {"ID":3,"Name":"Cappucino cup","Slug":"cappucino","SizeMl":200,"LUT":"[[30, 41, 1.36], [60, 58, 0.567], [90, 70, 0.4], [180, 136, 0.733], [200, 150, 0.733]]"}};
  var FluxxorTestUtils = require('fluxxor-test-utils');
  var fakeFlux = FluxxorTestUtils.fakeFlux();

  //  Render a Beverage
  var cappucino = TestUtils.renderIntoDocument(
      <Beverage beverage={beverage} country="CH" flux={fakeFlux} />
  );

  it('can make a cappucino', function() {
    var ingredientHeight = cappucino.getIngredientHeight();
    var heights = ingredientHeight(60);
    expect(heights).toEqual([0, 58]);
    heights = ingredientHeight(60);
    expect(heights).toEqual([58, 91.99]);
    heights = ingredientHeight(60);
    expect(heights).toEqual([91.99, 136]);
  });

});
