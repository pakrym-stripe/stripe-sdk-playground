import { readFileSync } from 'fs';
import Stripe from "stripe";

const stripe = new Stripe(readFileSync('../api_key').toString(), 
  { apiVersion: '2020-08-27' }
  // set custom API version or beta flags
  // @ts-ignore
  //{ apiVersion: '2020-08-27;search_api_beta=v1' }
);


(async () => {
  // use stripe here
  for await (const charge of stripe.charges.list()) {
    console.log(charge.id);
  }
})();
