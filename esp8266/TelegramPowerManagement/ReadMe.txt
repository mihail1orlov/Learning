# TelegramPowerManagement — design notes

A small ESP8266 project that exposes power control (LEDs, eventually
relays) over a Telegram bot. The board can either join an existing Wi-Fi
network or fall back to an access-point setup mode if no Wi-Fi is
configured yet.

It's not as easy as it sounds.

## Open questions

- Need a working example of in-firmware Wi-Fi selection (scan + connect).

## Modes

### Access-point mode

The ESP8266 brings up its own SoftAP. Once connected, the user is shown
a list of available Wi-Fi networks and picks one.

### Working mode (basic)

- Receives requests over Telegram.
- Responds only to specific user IDs.

### Working mode (advanced)

- Add new users at runtime.
- Subscribe to topics for notifications.
- Voice control.

## Status

Legend: `+` done, `*` in progress, `-` outstanding.

- [+] Run a Telegram bot
- [-] Turn an LED on and off
  - [+] Change response logic
  - [+] Use an allow-list of user IDs
  - [-] Reply to unregistered users with a polite "no"
- [*] Refactor to an OOP layout
- [-] Set up access-point mode
  - LED indicator behaviour:
    - solid          — connected to Wi-Fi
    - slow blinking  — access-point mode
    - fast blinking  — fell back to AP mode (Wi-Fi lost)
- [-] After AP setup, switch to STA mode and connect to the chosen Wi-Fi
  - Start an HTTP server
    - Show the list of available networks
  - Persist the chosen Wi-Fi credentials
