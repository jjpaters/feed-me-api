#!/bin/bash

# Global Variables
FILEPATH="./FeedMe.Api/appsettings.json"

# Env Variables
AUTH_AUTHORITY=${AUTH_AUTHORITY}
AUTH_AUDIENCE=${AUTH_AUDIENCE}
DATABASE_URI=${DATABASE_URI}

echo "Starting to replace the AWS environment variables."

sed -i -e "s,\#{AUTH_AUTHORITY}\#,"AUTH_AUTHORITY",g"\
    -e "s,\#{AUTH_AUDIENCE}\#,"AUTH_AUDIENCE",g"\
    -e "s,\#{DATABASE_URI}\#,"DATABASE_URI",g"\
    $FILEPATH