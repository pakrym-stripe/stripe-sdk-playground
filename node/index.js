const { readFileSync } = require('fs');
const Stripe = require("stripe");

const stripe = Stripe(readFileSync('../api_key').toString(), {
  // set custom API version or beta flags
  // apiVersion: '2020-08-27;search_api_beta=v1'
});

(async () => {
  // use stripe here
  for await (const charge of stripe.charges.list()) {
    console.log(charge.id);
  }
})();
