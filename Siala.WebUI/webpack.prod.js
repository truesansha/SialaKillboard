var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');
var CleanWebpackPlugin = require('clean-webpack-plugin');
var ngToolsWebpack = require('@ngtools/webpack');

var ROOT = path.resolve(__dirname, '.');

console.log('@@@@@@@@@ USING PRODUCTION @@@@@@@@@@@@@@@');

module.exports = {

    entry: {
        'vendor': './Scripts/vendor.ts',
        'polyfills': './Scripts/polyfills.ts',
        'app': './Scripts/main.ts'
    },

    output: {
        path: ROOT + '/wwwroot/',
        filename: 'js/[name].[hash].bundle.js',
        chunkFilename: 'js/[id].[hash].chunk.js',
        publicPath: '/'
    },

    resolve: {
        extensions: ['.ts', '.js', '.json']
    },

    module: {
        rules: [
            {
                test: /\.ts$/,
                use: '@ngtools/webpack'
            },
            {
                test: /\.(png|jpg|gif|woff|woff2|ttf|svg|eot)$/,
                use: 'file-loader?name=assets/[name]-[hash:6].[ext]'
            },
            {
                test: /favicon.ico$/,
                use: 'file-loader?name=/[name].[ext]'
            },
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    'css-loader'
                ]
            },
            {
                test: /\.html$/,
                use: 'raw-loader'
            }
        ],
        exprContextCritical: false
    },

    plugins: [
        new ngToolsWebpack.AotPlugin({
            tsConfigPath: './tsconfig-aot.json'
        }),
        new CleanWebpackPlugin(
            [
                './wwwroot/js',
                './wwwroot/assets'
            ],
            { root: ROOT }
        ),
        new webpack.NoEmitOnErrorsPlugin(),
        new webpack.optimize.UglifyJsPlugin({
            compress: {
                warnings: false
            },
            output: {
                comments: false
            },
            sourceMap: false
        }),
        new webpack.optimize.CommonsChunkPlugin(
            {
                name: ['vendor', 'polyfills']
            }),

        new HtmlWebpackPlugin({
            filename: 'index.html',
            inject: 'body',
            template: 'Scripts/app/index.html'
        }),

        new CopyWebpackPlugin([
            { from: './Scripts/assets/images/*.*', to: 'assets/', flatten: true }
        ])
    ]
};

