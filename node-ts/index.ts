import { readFileSync } from 'fs';
import Stripe from "stripe";

const stripe = new Stripe(readFileSync('../api_key').toString(), 
  // set custom API version or beta flags
  // @ts-ignore
  { apiVersion: '2020-08-27;terminal_server_driven_beta=v1' }
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
