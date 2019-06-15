const express = require('express');
const router = express.Router();
const Recipe = require('./recipes.model');
const jwtCheck = require('../../jwtCheck');

router.delete('/:id', jwtCheck, function (req, res, next) {
    Recipe.findByIdAndDelete({ _id: req.params.id }).then(function () {
        res.status(204).send();
    }, function (err) {
        res.status(500).send(err);
    });
})

router.get('/', jwtCheck, function (req, res, next) {
    Recipe.find({ userId: req.query.userId }).then(function (recipes) {
        const status = (recipes) ? 200 : 404;
        res.status(status).send(recipes);
    }, function (err) {
        res.status(500).send(err);
    });
});

router.get('/:id', jwtCheck, function (req, res, next) {
    Recipe.findById({ _id: req.params.id }).then(function (recipe) {
        const status = (recipe) ? 200 : 404;
        res.status(status).send(recipe);
    }, function (err) {
        res.status(500).send(err);
    });
});

router.post('/', jwtCheck, function (req, res, next) {
    const createRecipe = new Recipe({
        title: req.body.title,
        description: req.body.description,
        userId: req.body.userId
    });

    createRecipe.save().then(function (recipe) {
        res.status(201).send(recipe);
    }, function (err) {
        if (err.name === 'ValidationError') {
            res.status(400).send(err);
        } else {
            res.status(500).send(err);
        }
    });
});

router.put('/:id', jwtCheck, function (req, res, next) {
    const updateRecipe = new Recipe({
        _id: req.params.id,
        title: req.body.title,
        description: req.body.description,
        updated: new Date()
    });

    Recipe.findByIdAndUpdate({ _id: req.params.id }, updateRecipe, { new: true }).then(function (recipe) {
        res.status(200).send(recipe);
    }, function (err) {
        if (err.name === 'ValidationError') {
            res.status(400).send(err);
        } else {
            res.status(500).send(err);
        }
    });
});

module.exports = router;
