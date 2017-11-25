const webpack = require('webpack');
const path = require('path');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: {
        caseSheet: './App/CaseSheets/index.tsx'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/js'),
        filename: '[name].bundle.js',
        libraryTarget: 'var',
        library: '[name]'
    },
    module: {
        rules: [
            { test: /\.tsx?$/, use: 'awesome-typescript-loader' }
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
            { from: './node_modules/rigby/dist', to: path.resolve(__dirname, './wwwroot/js/lib/rigby') }
        ])
    ],
    externals: {
        'react': 'React',
        'react-dom': 'ReactDOM',
        'rigby': 'rigby'
    }
}