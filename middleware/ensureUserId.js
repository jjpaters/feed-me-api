module.exports = {
    exists: function (req, res, next) {
        if (req.userId !== undefined) {
            next();
        } else {
            res.status(401).send('User ID is not valid');
        }
    },

    matchesQueryParam: function (req, res, next) {
        if (req.userId !== undefined && req.userId === req.query.userId) {
            next();
        } else {
            res.status(401).send('User ID is not valid');
        }
    }
}
