const mongoose = require('mongoose');
const Schema = mongoose.Schema;

var RecipeSchema = new Schema({
    title: { type: String, required: true },
    description: { type: String, required: true },
    userId: { type: String, required: true },
    updated: { type: Date, default: Date.now() },
});

module.exports =  mongoose.model('Recipe', RecipeSchema);