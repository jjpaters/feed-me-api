import express, { Response, Request, NextFunction } from 'express';
import createError from 'http-errors';
import cookieParser from 'cookie-parser';
import logger from 'morgan';

import { NeighborhoodController } from './api/neighborhoods/neighborhood.controller';

const app: express.Application = express();
const port = (process.env.PORT || '3000');


app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());

app.use('/api/', new NeighborhoodController().router),

app.use((req: Request, res: Response, next: NextFunction) => {
    next(createError(404));
});

app.listen(port, () => {
    console.log(`Feed Me API is listening on port: ${port}`);
});