const express = require('express');
const router = express.Router();
const mongoose = require('mongoose');

router.get('/', function (req, res, next) {
    res.send({
        status: 'pass',
        database: (mongoose.connection.readyState === 1)
    });
});

module.exports = router;
