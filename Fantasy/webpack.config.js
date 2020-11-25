const path = require('path');

module.exports = {
    entry: './Scripts/main.js',
    output: {
        filename: 'app.js',
        path: path.resolve(__dirname, './wwwroot/js'),
    },
    mode: 'development'
};