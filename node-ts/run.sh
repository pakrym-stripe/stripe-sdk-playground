#!/bin/sh
set -e
../init.sh
yarn
npx tsc --project tsconfig.json
node index.js