const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const RecipeSchema = new Schema({
    title: { type: String, required: true },
    description: { type: String, required: true },
    prepTime: { type: String, required: true },
    cookTime: { type: String, required: true },
    servings: { type: Number, required: true, min: 1 },
    ingredients: [{ type: String, require: true }],
    steps: [{ type: String, require: true }],
    userId: { type: String, required: true },
    updated: { type: Date, default: Date.now() },
});

RecipeSchema.set('toJSON', {
    virtuals: true
});

module.exports =  mongoose.model('Recipe', RecipeSchema);