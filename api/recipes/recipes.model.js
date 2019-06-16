const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const RecipeSchema = new Schema({
    title: { type: String, required: true },
    description: { type: String, required: true },
    userId: { type: String, required: true },
    updated: { type: Date, default: Date.now() },
});

RecipeSchema.set('toJSON', {
    virtuals: true
});

module.exports =  mongoose.model('Recipe', RecipeSchema);