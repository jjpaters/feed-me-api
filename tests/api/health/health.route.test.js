const request = require('supertest');

let req = {
    body: {}
};

let res = {
    sendCalledWith: '',
    send: function (arg) {
        this.sendCalledWith(arg);
    }
};

describe('Health Route', function () {
    describe('GET api/health', function () {

        var server;

        beforeEach(function () {
            delete require.cache[require.resolve('../../../bin/www')];
            server = require('../../../bin/www', { bustCache: true });
        });

        afterEach(function (done) {
            server.close(done);
        })

        it('Should return a http status code of 200', function (done) {
            request(server)
                .get('/api/health')
                .expect(200, done);
        });

        it('Should return status of "pass"', function (done) {
            request(server)
                .get('/api/health')
                .expect(200, {
                    status: 'pass',
                    database: false
                }, done);
        });
    });
});