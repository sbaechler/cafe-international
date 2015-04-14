var React = require("react"),
    classNames = require("classnames"),
    _ = require("lodash");



/**
 * A single beverage.
 * @param {object} beverage - The beverage object as delivered by the JSON
 */
var Beverage = React.createClass({

  /**
   * Calculates the height of the beverage.
   * Stores the previous height on successive calls.
   * @param {number} amount - Amount in ml
   * @return {number} height in Pixels.
   */
  getBeverageHeight: function() {
    var currentHeightPx = 0,
        currentAmountMl = 0,
        LUT = JSON.parse(this.props.beverage.cup.LUT);
    return function(amount){
      var lastAmount = currentAmountMl,
          lastIngredient = currentAmountMl;
      _.forEach(LUT, function(val) {
        if(val[0] === (amount + currentAmountMl)) {
          currentHeightPx = val[1];
          currentAmountMl += amount;
          return false;
        } else if (val[0] > currentAmountMl && val[0] < (amount + currentAmountMl)) {
          currentHeightPx = val[1];
          lastAmount = val[0];
        } else if (val[0] > currentAmountMl && val[0] > (amount + currentAmountMl)) {
          currentHeightPx += val[2] * (amount + currentAmountMl - lastAmount);
          currentAmountMl += amount;
          return false;
        }
      });
      return [lastIngredient, currentHeightPx];
    };
  },


  render: function() {
    var beverage = this.props.beverage,
        cup = beverage.cup.Slug,
        beverageHeight = this.getBeverageHeight(),
        fillState = 0;
    cssClasses = classNames('beverage', cup);
    var fillUp = _.map(beverage.Ingredients, function(hasIngredient) {
      var heights = beverageHeight(hasIngredient.AmountMl);
      fillState = _.max([fillState, heights[1]]);
      return(<div className={classNames('ingredient', hasIngredient.Ingredient.Slug)}
                  style={{height: heights[1]+'px', bottom: heights[0]+'px'}}>
      </div>);
    });
    return (
        <div className={cssClasses}>
          {fillUp}
          <div className="cup-overlay"></div>
          <div className="cup-shadow" style={{height: fillState+'px'}}></div>
          <p className="description">{beverage.Name}: {beverage.cup.Name}</p>
        </div>
    );
  }
});

module.exports = Beverage;
