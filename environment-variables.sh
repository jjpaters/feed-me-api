#!/bin/bash

# Global Variables
FILEPATH="./package/appsettings.json"

# AWS Variables
AWS_REGION=${AWS_REGION}
AWS_USERPOOL_CLIENT_ID=${AWS_USERPOOL_CLIENT_ID}
AWS_USERPOOL_ID=${AWS_USERPOOL_ID}

echo "Starting to replace the AWS environment variables."

sed -i -e "s,\#{AWS_REGION}\#,"AWS_REGION",g" -e "s,\#{AWS_USERPOOL_CLIENT_ID}\#,"AWS_USERPOOL_CLIENT_ID",g" -e "s,\#{AWS_USERPOOL_ID}\#,"AWS_USERPOOL_ID",g" $FILEPATH
