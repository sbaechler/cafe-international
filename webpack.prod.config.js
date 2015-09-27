var webpack = require('webpack');

module.exports = {
  entry: {
    app: [
      "./src/scripts/main.js"
    ]
  },
  output: {
    path: "./build",
    filename: "bundle.js"
  },
  plugins: [
    new webpack.NoErrorsPlugin()
  ],
  resolve: {
    modulesDirectories: ['node_modules'],
  },
  module: {
    loaders: [
      {
        test: /\.jsx?$/,
        loader: "jsx",
        exclude: /node_modules/
      },

      {
        test: /\.scss$/,
        loader: "style!css!sass?outputStyle=expanded"
      },

      
      {
        test: /\.(png|jpg)$/,
        loader: 'url-loader?limit=8192'
      },

      {
        test: /\.html$/,
        loader: "file?name=[path][name].[ext]&context=./src"
      }
    ]
  }
};
