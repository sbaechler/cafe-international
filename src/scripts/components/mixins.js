var Fluxxor = require("fluxxor"),
    React = require("react");

var FluxMixin = Fluxxor.FluxMixin(React);

module.exports = {
  FluxMixin: FluxMixin,
  StoreWatchMixin: Fluxxor.StoreWatchMixin
};
