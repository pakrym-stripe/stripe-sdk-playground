require 'bundler/inline'

gemfile do
    gem "stripe", path: "../sdks-root/stripe-ruby/"
end

Stripe.api_key = File.read('../api_key')
Stripe.api_version = File.read('../api_version')
# list customers

Stripe::Terminal::Reader::TestHelpers.simulate_payment('tmr_EihpMAqu6AYhxl')
