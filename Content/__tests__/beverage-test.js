/**
 * @jsx React.DOM
 * Unit tests for the BeverageList and Beverage components.
 */
jest.dontMock('../components/Beverage.jsx');

describe('Espressos', function(){
  var React = require("react/addons");

  var Beverage = require('../components/Beverage.jsx');
  var TestUtils = React.addons.TestUtils;

  var beverage = {"Countries":[{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"de-ch"},{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"fr-ch"}],"Ingredients":[{"Ingredient":{"ID":1,"Name":"espresso","Slug":"espresso"},"Position":1,"AmountMl":30,"AmountOz":1}],"ID":2,"Name":"Espresso","Slug":"espresso","Strength":8,"Comment":null,"CupID":1,
    cup: {"ID":1,"Name":"Demitasse","Slug":"demitasse","SizeMl":90,"LUT":"[[20, 29, 1.45], [30, 43, 1.4], [60, 78, 1.16],[90, 104, 0.866]]"}};

  //  Render a Beverage
  var espresso = TestUtils.renderIntoDocument(
      <Beverage beverage={beverage} />
  );

  it('can make a simple espresso', function() {
    // check the fill function for a single ingredient
    var beverageHeight = espresso.getBeverageHeight();
    var heights = beverageHeight(30);
    expect(heights).toEqual([0, 43]);
  });

  it('can calculate the fill function for multiple ingredients at known levels', function() {
    var beverageHeight = espresso.getBeverageHeight();
    var heights = beverageHeight(20);
    expect(heights).toEqual([0, 29]);
    heights = beverageHeight(10);
    expect(heights).toEqual([29, 43]);
    heights = beverageHeight(30);
    expect(heights).toEqual([43, 78]);
    heights = beverageHeight(30);
    expect(heights).toEqual([78, 104]);
  });

  it('can calculate the fill function for multiple ingredients at unknown levels.', function(){
    var beverageHeight = espresso.getBeverageHeight();
    var heights = beverageHeight(0);
    expect(heights).toEqual([0, 0]);

    //                    0,  10,   20, 30, 40,   50,   60, 70,    80,    90
    var expectedHeights = [0, 14.5, 29, 43, 54.6, 66.2, 78, 86.66, 95.32, 104];
    for(var i=0; i<(expectedHeights.length-1); i++) {
      heights = beverageHeight(10);
      expect(heights).toEqual([expectedHeights[i], expectedHeights[i+1]]);
    }

  });

  it('can calculate the fill function for multiple ingredients and go past a data point', function(){
    var beverageHeight = espresso.getBeverageHeight();
    var heights = beverageHeight(10);
    expect(heights).toEqual([0, 14.5]);
    heights = beverageHeight(40);
    expect(heights).toEqual([14.5, 66.2]);
  });

});
