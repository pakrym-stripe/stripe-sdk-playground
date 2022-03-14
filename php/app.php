<?php

require_once('vendor/autoload.php');

$stripe = new \Stripe\StripeClient([
    'api_key' => file_get_contents("../api_key"),
    'stripe_version' => file_get_contents("../api_version"),
]);
$stripe->testHelpers->terminal->readers->simulatePayment("tmr_EihpMAqu6AYhxl");