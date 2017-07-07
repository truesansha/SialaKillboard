var Environment = (process.env.NODE_ENV || "development").trim();

if (Environment === "development") {
    module.exports = require("./webpack.dev.js");
} else {
    module.exports = require("./webpack.prod.js");
}