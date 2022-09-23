[![CircleCI](https://circleci.com/gh/jjpaters/feed-me-api/tree/main.svg?style=svg)](https://circleci.com/gh/jjpaters/feed-me-api/tree/main)

# Feed Me API

Backend for [Feed Me](https://feed-me.io/)

## Local Development 

Download [DynamoDB Local](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DynamoDBLocal.DownloadingAndRunning.html).  For this README, assume the files are located in the `C:/Tools/DynamoDbLocal` directory.

Run:

```
java -Djava.library.path=C:/Tools/DynamoDbLocal/DynamoDBLocal_lib -jar C:/Tools/DynamoDbLocal/DynamoDBLocal.jar -sharedDb
```

Connect using dotnet, or NoSQL Workbench.