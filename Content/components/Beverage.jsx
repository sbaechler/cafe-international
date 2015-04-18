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
   * @return {Array} base line height, div height in Pixels.
   */
  getBeverageHeight: function() {
    var currentHeightPx = 0, // store the current height of the beverage in the cup.
        currentAmountMl = 0, // store the amount of liquid in the cup.
        LUT = JSON.parse(this.props.beverage.cup.LUT);
    return function(amount){
      //console.log('current Amount: ', currentAmountMl, ' adding: ', amount, 'ml.');
      //console.log('current height: ' + currentHeightPx+ 'Px.');
      var lastVal = [currentAmountMl, currentHeightPx],
          // store the previous value to return it as base height.
          lastHeightPx = currentHeightPx,
          dx=1, dy=0;
      _.forEach(LUT, function(val, i) {
        //console.log(''+i+':Traversing LUT at ' + val[0]);
        if(val[0] === (amount + currentAmountMl)) {
          // the amount is a data point
          currentHeightPx = val[1];
          currentAmountMl = val[0];
          //console.log('value found.', val[0]);
          return false;
        } else if (val[0] >= currentAmountMl && val[0] < (amount + currentAmountMl)) {
          // the data point is at or above the current amount but below the new amount:
          // store the amount for future calculation.
          lastVal = val;
          //console.log('storing ', val);
        } else if (val[0] > currentAmountMl && val[0] >= (amount + currentAmountMl)) {
          // the amount passed the data point: calculate the difference to the last known value.
          dx = currentAmountMl + amount - lastVal[0];
          dy =  val[2] * dx;
          //console.log('passed height of ', amount+currentAmountMl);
          //console.log('dx: ', dx, ' dy: ', dy);
          // store the last known y-value plus the calculated dy.
          currentHeightPx = lastVal[1] + dy;
          currentAmountMl += amount;
          //console.log('new values: amount: ', currentAmountMl, 'height ', currentHeightPx);
          return false;
        }
      });
      //console.log('returning ', lastHeightPx, currentHeightPx);
      return [lastHeightPx, currentHeightPx];
    };
  },


  render: function() {
    var beverage = this.props.beverage,
        cup = beverage.cup.Slug,
        beverageHeight = this.getBeverageHeight(),
        fillState = 0;
    cssClasses = classNames('beverage', cup);
    // create the HTML divs with the correct height.
    var fillUp = _.map(beverage.Ingredients, function(hasIngredient) {
      var heights = beverageHeight(hasIngredient.AmountMl);
      fillState = _.max([fillState, heights[1]]);
      return(<div className={classNames('ingredient', hasIngredient.Ingredient.Slug)}
                  key={hasIngredient.Position}
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
