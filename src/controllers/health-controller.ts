import { APIGatewayEvent } from 'aws-lambda';
import { ApiResponse } from '../models/api-response';
import { HttpStatusCodes } from '../models/http-status-codes';

export class HealthController {

    static handle(event: APIGatewayEvent): ApiResponse {
        let response: ApiResponse;

        switch (event.httpMethod) {
            case 'GET':
                response = this.getEvent();
                break;
            default:
                throw new Error(`Unsupported method "${event.httpMethod}"`);
        }

        return response;
    }

    static getEvent(): ApiResponse {
        const response = new ApiResponse();
        response.body = { 'status': 'Pass' }
        response.statusCode = HttpStatusCodes.OK;
        return response;
    }

}
