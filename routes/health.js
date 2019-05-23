const express = require('express');
const router = express.Router();

router.get('/', function(req, res, next) {
  res.send({
      status: 'pass',
      statusDate: new Date()
  });
});

module.exports = router;
