import express, { Request, Response, Router } from 'express';

export class NeighborhoodController {
    public router: Router = express.Router();

    constructor() {
        this.router.get('/neighborhoods', this.getAllNeighborhoods);
    }

    getAllNeighborhoods(req: Request, res: Response) {
        res.send([
            {
                neighborhoodId: '1'
            }
        ]);
    }
}