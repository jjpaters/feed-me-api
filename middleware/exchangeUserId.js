const request = require('request');

function exchangeUserId(req, res, next) {
    if (req.headers.authorization !== undefined) {
        try {
            const options = {
                url: process.env.AUTH_ISSUER + 'userinfo',
                method: 'GET',
                headers: {
                    'Authorization': req.headers.authorization
                }
            };
    
            request.get(options, function (error, response, body) {
                if (response.statusCode === 200) {
                    req.userId = JSON.parse(body).sub;
                    next();
                } else {
                    res.status(401).send('Unable to resolve user the from access_token.');
                }
            });
        }
        catch (ex) {
            console.log('Error: ' + ex);
            next();
        }
    } else {
        next();
    }
}

module.exports = exchangeUserId;