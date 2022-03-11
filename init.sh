#!/bin/sh
set -e
BASEDIR=$(dirname "$0")

if [ ! -e "$BASEDIR/api_key" ]
then
    echo "ERROR: $BASEDIR/api_key file not found"
    exit 1
fi

if [ ! -e "$BASEDIR/sdks-root" ]
then
    ln -s ~/stripe "$BASEDIR/sdks-root"
fi