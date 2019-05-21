import * as mongoose from 'mongoose';
import Recipe from './recipe';
 
const recipeSchema = new mongoose.Schema({
  recipeId: String,
  userId: String,
  recipeName: String,
  recipeDescription: String,
});

const RecipeModel = mongoose.model<Recipe & mongoose.Document>('Recipe', recipeSchema);

export default RecipeModel;