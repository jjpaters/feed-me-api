import { APIGatewayEvent } from 'aws-lambda';
import { HealthController } from './controllers/health-controller';
import { ApiResponse } from './models/api-response';
import { HttpStatusCodes } from './models/http-status-codes';

export const handler = async (event: APIGatewayEvent): Promise<any> => {

    const headers = {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET,OPTIONS',
        'Access-Control-Allow-Headers': 'Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token'
    };

    let response: ApiResponse;

    try {
        const resource = event.resource.slice(1).toLowerCase();

        switch (resource) {
            case 'health':
                response = HealthController.handle(event);
                break;
            default:
                throw new Error(`Unsupported resource "${resource}"`);
        }
    } catch (ex) {
        response = new ApiResponse();
        response.statusCode = HttpStatusCodes.INTERNAL_SERVER_ERROR;
        response.body = ex.message;
    }

    return {
        statusCode: response.statusCode,
        body: JSON.stringify(response.body),
        headers
    };
};
