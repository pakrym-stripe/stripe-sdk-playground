#!/bin/sh
set -e
../init.sh
composer install
php ./app.php