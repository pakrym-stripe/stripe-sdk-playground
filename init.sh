#!/bin/sh
set -e
if [ -e api_key ]
then
    echo "ERROR: api_key file not found"
    exit 1
fi

if [ -e sdks-root ]
then
    exit
else
    ln -s ~/stripe sdks-root
fi