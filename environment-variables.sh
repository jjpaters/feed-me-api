#!/bin/bash

# Global Variables
FILEPATH="./FeedMe.Api/appsettings.json"

# Env Variables
AUTH_AUTHORITY=${AUTH_AUTHORITY}
AUTH_AUDIENCE=${AUTH_AUDIENCE}
DYNAMO_ACCESS_KEY=${DYNAMO_ACCESS_KEY}
DYNAMO_SECRET_KEY=${DYNAMO_SECRET_KEY}

echo "Starting to replace the AWS environment variables."

sed -i -e "s,\#{AUTH_AUTHORITY}\#,"AUTH_AUTHORITY",g"\
    -e "s,\#{DYNAMO_ACCESS_KEY}\#,"DYNAMO_ACCESS_KEY",g"\
    -e "s,\#{DYNAMO_SECRET_KEY}\#,"DYNAMO_SECRET_KEY",g"\
    $FILEPATH