CREATE DATABASE IF NOT EXISTS FeedMe;

USE FeedMe;

CREATE TABLE IF NOT EXISTS UserRecipes (
	UserRecipeId INT NOT NULL AUTO_INCREMENT,
    UserRecipeTitle VARCHAR(100) NOT NULL,
    UserRecipeDescription VARCHAR(1000),
    Category VARCHAR(25),
    Servings VARCHAR(25),
    PrepTime VARCHAR(25),
    CookTime VARCHAR(25),
    UserId VARCHAR(50) NOT NULL,
    PRIMARY KEY (UserRecipeId),
    INDEX (UserRecipeId, UserId)
);

CREATE TABLE IF NOT EXISTS UserIngredients (
	UserIngredientId INT NOT NULL AUTO_INCREMENT,
    UserIngredientText VARCHAR(100) NOT NULL,
    UserRecipeId INT NOT NULL,
    PRIMARY KEY (UserIngredientId),
    INDEX (UserIngredientId, UserRecipeId)
);

CREATE TABLE IF NOT EXISTS UserSteps (
	UserStepId INT NOT NULL AUTO_INCREMENT,
    UserStepText VARCHAR(500) NOT NULL,
    UserOrderNumber INT NOT NULL,
    UserRecipeId INT NOT NULL,
    PRIMARY KEY (UserStepId),
    INDEX (UserStepId, UserRecipeId)
);
