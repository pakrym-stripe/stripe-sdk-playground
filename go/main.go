package main

import (
	"io/ioutil"

	"github.com/stripe/stripe-go/v72"
	"github.com/stripe/stripe-go/v72/testhelpers/terminal/reader"
)

func main() {
	key, _ := ioutil.ReadFile("../api_key")
	stripe.Key = string(key)

	reader.SimulatePayment("tmr_EihpMAqu6AYhxl", &stripe.TestHelpersTerminalReaderSimulatePaymentParams{})
}
