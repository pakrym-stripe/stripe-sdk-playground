#!/bin/sh
set -e
../init.sh
rm -r vendor
mkdir -p vendor/github.com/stripe/stripe-go
ln -s "$(pwd)/../sdks-root/stripe-go" vendor/github.com/stripe/stripe-go/v72
go run .