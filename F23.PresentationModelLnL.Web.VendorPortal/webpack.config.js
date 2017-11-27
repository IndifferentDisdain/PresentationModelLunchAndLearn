const webpack = require('webpack');
const path = require('path');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: {
        caseSheet: './App/CaseSheets/index.tsx'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/js'),
        publicPath: '/js/',
        filename: '[name].bundle.js'
    },
    resolve: {
        extensions: [ '.ts', '.tsx', '.js', '.jsx' ]
    },
    devtool: 'source-map',
    module: {
        rules: [
            { test: /\.tsx?$/, exclude: /node_modules/, loaders: ['react-hot-loader/webpack', 'awesome-typescript-loader'] }
        ]
    },
    plugins: [
        //new webpack.optimize.UglifyJsPlugin(),
        // CDN fallback packages
        new CopyWebpackPlugin([
            { from: './node_modules/bootstrap/dist', to: path.resolve(__dirname, './wwwroot/js/lib/bootstrap') },
            { from: './node_modules/jquery/dist', to: path.resolve(__dirname, './wwwroot/js/lib/jquery') },
            { from: './node_modules/react/umd', to: path.resolve(__dirname, './wwwroot/js/lib/react') },
            { from: './node_modules/react-dom/umd', to: path.resolve(__dirname, './wwwroot/js/lib/react-dom') },
            { from: './node_modules/rigby/dist', to: path.resolve(__dirname, './wwwroot/js/lib/rigby') },
            { from: './node_modules/react-select/dist', to: path.resolve(__dirname, './wwwroot/css') }
        ])
    ],
    externals: {
        'react': 'React',
        'react-dom': 'ReactDOM',
        'rigby': 'Rigby'
    }
}