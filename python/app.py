import stripe
from pathlib import Path

stripe.api_key = Path('../api_key').read_text()
stripe.api_version = Path('../api_version').read_text()

stripe.terminal.Reader.TestHelpers.simulate_payment("tmr_EihpMAqu6AYhxl")