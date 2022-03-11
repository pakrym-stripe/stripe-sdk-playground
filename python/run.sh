#!/bin/sh
set -e
../init.sh
(cd ../sdks-root/stripe-python && make) &&  ../sdks-root/stripe-python/venv/bin/python app.py 
