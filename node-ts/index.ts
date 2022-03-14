import { readFileSync } from 'fs';
import Stripe from "stripe";

const key = readFileSync('../api_key').toString();
const version = readFileSync('../api_version').toString();

const stripe = new Stripe(key.toString(),
  // @ts-ignore
  { apiVersion: version.toString() }
);

(async () => {
  // use stripe here
  stripe.testHelpers.terminal.readers.simulatePayment("tmr_EihpMAqu6AYhxl", {
    type: "card_present",
    card_present: {
      number:"123123123123"
    },
  })
})();
