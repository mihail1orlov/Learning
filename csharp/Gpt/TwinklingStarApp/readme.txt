# TwinklingStarApp

A small C# console toy that paints a starry sky: many stars, each blinking
independently with a random colour, at random positions, on its own random
schedule. The whole console buffer is used as the canvas.

## How the code is organised

* `Star` represents a single star. It holds an `(x, y)` position and a
  `ConsoleColor`. It exposes two methods:
  * `Draw` — paints the star at its current location.
  * `Twinkle` — flips the star to white briefly, sleeps for a random
    interval, then redraws it in its assigned colour.

* `Program` is the entry point. It:
  1. Sets the console window size,
  2. Builds an array of `Star` instances at random positions with random
     colours,
  3. Loops forever, asking each star to twinkle.

Star colours are picked randomly from the `ConsoleColor` enum.

## Possible follow-ups

* Add a small random drift to the `(x, y)` coordinates inside `Twinkle` so
  that stars wiggle slightly instead of being perfectly stationary.
