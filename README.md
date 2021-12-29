[![CircleCI](https://circleci.com/gh/jjpaters/feed-me-api/tree/master.svg?style=svg)](https://circleci.com/gh/jjpaters/feed-me-api/tree/master)
[![DeepScan grade](https://deepscan.io/api/teams/3232/projects/8823/branches/112128/badge/grade.svg)](https://deepscan.io/dashboard#view=project&tid=3232&pid=8823&bid=112128)

# Feed Me API

Backend for [Feed Me](https://feed-me.io/)

## Here are some steps to follow from Visual Studio:

To deploy your Serverless application, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed application open the Stack View window by double-clicking the stack name shown beneath the AWS CloudFormation node in the AWS Explorer tree. The Stack View also displays the root URL to your published application.

## Here are some steps to follow to get started from the command line:

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.
```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```
    dotnet tool update -g Amazon.Lambda.Tools
```

Execute unit tests
```
    cd "FeedMe.Api/test/FeedMe.Api.Tests"
    dotnet test
```

Deploy application
```
    cd "FeedMe.Api/src/FeedMe.Api"
    dotnet lambda deploy-serverless
```
