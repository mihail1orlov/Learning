It's not as easy as it seems, 


Questions:
  - You need to find an example of choosing a Wi-Fi network.

Description:
Access point mode
  esp8266 starts working as an access point, after connecting it prompts you to select
  an availble WiFi network

Work mode:
  Request responce
  Response for specific users only

Advanced work mode:
  Implement a possibility for adding users
    Response for specific users only
  The ability to subscribe to topics
  Implement voice control

Steps:
  + run telegram bot
  - turn LED on and off
    + I need to change the logic of the responce
    + only allowed user IDs need to be used
    - implement the ability to reply to unregistered users
  * change project to OOP convention
  - setup access point
    - LED indication
      - constantly shining - esp connected to the wi-fi
      - slow blinking - access point mode
      - fast blinking - return to access point mode (no WiFi)
  - after setup, connect to WiFi
    - start web server
      - show availble WiFi networks
    - setup WiFi connection