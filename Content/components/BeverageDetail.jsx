var React = require("react"),
    // https://github.com/marcio/react-skylight
    SkyLight = require('react-skylight'),
    mixins = require("./mixins"),
    classNames = require("classnames"),
    _ = require("lodash");

/**
 * The detail popup for a beverage. It shows additional informations about a beverage.
 * @param {object} flux - the Fluxxor instance.
 */
var BeverageDetail = React.createClass({
  mixins: [mixins.FluxMixin, mixins.StoreWatchMixin("detailStore")],

  getInitialState: function() {
    return {};
  },

  getStateFromFlux: function() {
    return this.getFlux().store("detailStore").getState();
  },

  componentDidMount: function(){
    document.addEventListener("keydown", function (e) {
      if ( this.state.isVisible && (e.keyCode === 27) ){
        this.getFlux().actions.toggleDetail();
      }
    }.bind(this));
  },

  componentDidUpdate: function(){
    if(this.state.isVisible) {
      this.refs.simpleDialog.show();
    } else {
      this.refs.simpleDialog.hide();
    }
  },

  render: function() {
    var beverage = this.state.beverage || {},
        closeButtonStyle = {
            cursor: 'pointer',
            float: 'right',
            fontSize: '25px',
            margin: '-30px 0',
            color: 'white',
            background: 'black',
            borderRadius: '20px',
            height: '32px',
            width: '40px',
            paddingTop: '8px',
            textAlign: 'center',
            border: '1px solid white',
            WebkitAppearance: 'button'
            };
    return(
    <SkyLight ref="simpleDialog"
              title={beverage.Name}
              closeButtonStyle={closeButtonStyle}>
      <div className="beverageDetail">Text </div>
    </SkyLight>
    );
  }


});

module.exports = BeverageDetail;