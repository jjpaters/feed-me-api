import { HttpStatusCodes } from './http-status-codes';

export class ApiResponse {
    body: any;
    statusCode?: HttpStatusCodes;
}
