var React = require("react"),
    _ = require("lodash"),
    Beverage = require('./Beverage');



/**
 * The list of beverages.
 * @param {object} beverages - The list of beverages.
 */
var BeverageList = React.createClass({

  render: function() {
    var beverages = _.map(this.props.beverages, function(beverage, key){
			return <Beverage key={key} beverage={beverage} />;
	  });
    return(<div className="beverageList clearfix">{beverages}</div>);
  }
});

module.exports = BeverageList;
