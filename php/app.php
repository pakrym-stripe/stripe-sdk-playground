<?php

require_once('vendor/autoload.php');

$stripe = new \Stripe\StripeClient([
    'api_key' => file_get_contents("../api_key"),
    'stripe_version' => '2020-08-27;terminal_server_driven_beta=v1',
]);
$stripe->testHelpers->terminal->readers->simulatePayment("tmr_EihpMAqu6AYhxl");