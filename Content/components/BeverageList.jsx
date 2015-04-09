var React = require("react"),
    mixins = require("./mixins"),
    _ = require("lodash");

/**
 * A single beverage.
 * @param {object} beverage - The beverage object as delivered by the JSON
 */
var Beverage = React.createClass({

  render: function() {
    var beverage = this.props.beverage,
        name = beverage.Name,
        ingredients = beverage.Ingredients,
        slug = beverage.Slug,
        strength = beverage.Strength,
        comment = beverage.Comment;
    return (
      <li cssClass="beverage">
        <p>{name}: {beverage.cup.Name}</p>
      </li>
    );
  }
});

/**
 * The list of beverages.
 * @param {object} flux - The flux object.
 */
var BeverageList = React.createClass({
	mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("BeverageStore")],

  getInitialState: function() {
    return {};
  },

  getStateFromFlux: function() {
    return this.getFlux().store("BeverageStore").getState();
  },

  render: function() {
    var beverages = _.map(this.state.beverages, function(beverage, key){
			return <Beverage key={key} beverage={beverage} />;
	  });
    return(
      <ul>
          {beverages}
      </ul>
    );
  }

});

module.exports = BeverageList;
