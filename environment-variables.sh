#!/bin/bash

# Global Variables
FILEPATH="./FeedMe.Api/appsettings.json"

<<<<<<< HEAD
# Env Variables
AUTH_AUTHORITY=${AUTH_AUTHORITY}
AUTH_AUDIENCE=${AUTH_AUDIENCE}

echo "Starting to replace the AWS environment variables."

sed -i -e "s,\#{AUTH_AUTHORITY}\#,"AUTH_AUTHORITY",g"\
    -e "s,\#{AUTH_AUDIENCE}\#,"AUTH_AUDIENCE",g"\
    $FILEPATH
=======
# AWS Variables
AWS_REGION=${AWS_REGION}
AWS_USERPOOL_CLIENT_ID=${AWS_USERPOOL_CLIENT_ID}
AWS_USERPOOL_CLIENT_SECRET=${AWS_USERPOOL_CLIENT_SECRET}
AWS_USERPOOL_ID=${AWS_USERPOOL_ID}

echo "Starting to replace the AWS environment variables."

sed -i -e "s,\#{AWS_REGION}\#,"AWS_REGION",g" -e "s,\#{AWS_USERPOOL_CLIENT_ID}\#,"AWS_USERPOOL_CLIENT_ID",g" -e "s,\#{AWS_USERPOOL_CLIENT_SECRET}\#,"AWS_USERPOOL_CLIENT_SECRET",g" -e "s,\#{AWS_USERPOOL_ID}\#,"AWS_USERPOOL_ID",g" $FILEPATH
>>>>>>> 187ac24890dc4eef43f04f37cf4f4ad2e9fb68e4
