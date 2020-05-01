import { APIGatewayEvent } from 'aws-lambda';

export const handler = async (event: APIGatewayEvent): Promise<any> => {
    let body: any;
    let statusCode = '200';
    const headers = {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET,OPTIONS',
        'Access-Control-Allow-Headers': 'Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token'
    };

    try {
        switch (event.httpMethod) {
            case 'GET':
                body = { 'status': 'Pass', 'resource': event.resource };
                break;
            default:
                throw new Error(`Unsupported method "${event.httpMethod}"`);
        }
    } catch (ex) {
        statusCode = '500';
        body = ex.message;
    } finally {
        body = JSON.stringify(body);
    }

    return {
        statusCode,
        body,
        headers
    };
};