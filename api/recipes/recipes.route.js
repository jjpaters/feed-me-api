const express = require('express');
const router = express.Router();
const Recipe = require('./recipes.model');
const jwtCheck = require('../../jwtCheck');
const ensureUserId = require('../../middleware/ensureUserId');

router.delete('/:id', jwtCheck, function (req, res, next) {
    Recipe.findById({ _id: req.params.id }).then(function (validateRecipe) {
        if (validateRecipe && validateRecipe.userId !== req.userId) {
            res.status(401).send('Not authorized to delete this recipe.');
        } else {
            Recipe.findByIdAndDelete({ _id: req.params.id }).then(function () {
                res.status(204).send();
            }, function (err) {
                res.status(500).send(err);
            });
        }
    }, function (err) {
        res.status(500).send(err);
    });
});

router.get('/', jwtCheck, ensureUserId.matchesQueryParam, function (req, res, next) {
    Recipe.find({ userId: req.userId }).then(function (recipes) {
        const status = (recipes) ? 200 : 404;
        res.status(status).send(recipes);
    }, function (err) {
        res.status(500).send(err);
    });
});

router.get('/:id', jwtCheck, ensureUserId.exists, function (req, res, next) {
    Recipe.findById({ _id: req.params.id }).then(function (recipe) {
        if (recipe && recipe.userId !== req.userId) {
            res.status(401).send('Not authorized to view this recipe.');
        } else {
            const status = (recipe) ? 200 : 404;
            res.status(status).send(recipe);
        }
    }, function (err) {
        res.status(500).send(err);
    });
});

router.post('/', jwtCheck, ensureUserId.exists, function (req, res, next) {
    const createRecipe = new Recipe({
        title: req.body.title,
        description: req.body.description,
        userId: req.userId
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

router.put('/:id', jwtCheck, ensureUserId.exists, function (req, res, next) {
    const updateRecipe = new Recipe({
        _id: req.params.id,
        title: req.body.title,
        description: req.body.description,
        updated: new Date()
    });

    Recipe.findById({ _id: req.params.id }).then(function (validateRecipe) {
        if (validateRecipe && validateRecipe.userId !== req.userId) {
            res.status(401).send('Not authorized to delete this recipe.');
        } else {
            Recipe.findByIdAndUpdate({ _id: req.params.id }, updateRecipe, { new: true }).then(function (recipe) {
                res.status(200).send(recipe);
            }, function (err) {
                if (err.name === 'ValidationError') {
                    res.status(400).send(err);
                } else {
                    res.status(500).send(err);
                }
            });
        }
    }, function (err) {
        res.status(500).send(err);
    });
});

module.exports = router;
