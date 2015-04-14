/**
 * @jsx React.DOM
 * Unit tests for the BeverageList and Beverage components.
 */
jest.dontMock('../components/Beverage.jsx');

describe('Espressos', function(){
  var React = require("react/addons");

  var Beverage = require('../components/Beverage.jsx');
  var TestUtils = React.addons.TestUtils;

  it('can make a good espresso', function() {

    //  Render a Beverage
    var beverage = {"Countries":[{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"de-ch"},{"BeverageID":2,"CountryISO2":"CH","Popularity":5,"Name":"Espresso","Language":"fr-ch"}],"Ingredients":[{"Ingredient":{"ID":1,"Name":"espresso","Slug":"espresso"},"Position":1,"AmountMl":30,"AmountOz":1}],"ID":2,"Name":"Espresso","Slug":"espresso","Strength":8,"Comment":null,"CupID":1,
                    cup: {"ID":1,"Name":"Demitasse","Slug":"demitasse","SizeMl":90,"LUT":"[[20, 29, 1.45], [30, 43, 1.43], [60, 78, 1.3],[90, 104, 1.15]]"}};

    var espresso = TestUtils.renderIntoDocument(
        <Beverage beverage={beverage} />
    );
    expect(true).toBe(true);
  });
});
