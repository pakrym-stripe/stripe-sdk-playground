const { readFileSync } = require('fs');
const Stripe = require("stripe");

const key = readFileSync('../api_key');
const version = readFileSync('../api_version');
const stripe = Stripe(key.toString(), {
  apiVersion: version.toString()
});

(async () => {
  // use stripe here
  for await (const charge of stripe.charges.list()) {
    console.log(charge.id);
  }
})();
