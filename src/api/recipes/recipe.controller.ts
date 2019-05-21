import express, { Request, Response, Router, NextFunction } from 'express';
import Recipe from './recipe';
import RecipeModel from './recipe.model';

export class RecipeController {

    public router: Router = express.Router();
    
    constructor() {
        this.router.post('/recipes', (req, res, next) => this.createRecipe(req, res, next));
    }

    async createRecipe(req: Request, res: Response, next: NextFunction): Promise<void> {
        try
        {
            const body: Recipe = req.body;
            const model = new RecipeModel(body);
            const savedRecipe: Recipe = await model.save();
            
            res.status(201).send(savedRecipe);
        } catch (error) {
            res.status(500).send(error);
        }
    }
}