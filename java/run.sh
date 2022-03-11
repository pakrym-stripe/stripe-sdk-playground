#!/bin/sh
set -e
../init.sh
(cd ../sdks-root/stripe-java; ./gradlew jar -q)
../sdks-root/stripe-java/gradlew run -q