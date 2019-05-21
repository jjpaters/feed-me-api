import express, { Response, Request, NextFunction } from 'express';
import createError from 'http-errors';
import cookieParser from 'cookie-parser';
import logger from 'morgan';
import { Mongoose } from 'mongoose';
import 'dotenv/config';

import { HeathController } from './api/diagostics/health.controller';
import { RecipeController } from './api/recipes/recipe.controller';

const app: express.Application = express();
const port = (process.env.PORT || '3000');
const mongoose = new Mongoose();

const {
  MONGODB_URI
} = process.env;

mongoose.connect(`${MONGODB_URI}`, { useNewUrlParser: true });

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());

app.use('/api/', new HeathController().router),
app.use('/api/', new RecipeController().router),

app.use((req: Request, res: Response, next: NextFunction) => {
    next(createError(404));
});

app.listen(port, () => {
    console.log(`Feed Me API is listening on port: ${port}`);
});