import express, { Request, Response, Router, NextFunction } from 'express';
import { Health } from './heath';

export class HeathController {

    public router: Router = express.Router();
    
    constructor() {
        this.router.get('/health', (req, res, next) => this.getHealth(req, res, next));
    }

    async getHealth(req: Request, res: Response, next: NextFunction): Promise<void> {
        try
        {
            const health = new Health();
            health.date = new Date();
            health.status = 'pass';

            res.status(200).send(health);
        } catch (error) {
            res.status(500).send(error);
        }
    }
}