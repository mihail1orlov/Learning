# History

1. **Using a space before the command:**
   - In many shell configurations, commands that begin with a space are not saved in the history. You can try executing the command like this:
     ```bash
     export GIT_TOKEN=YOUR_TOKEN
     ```
     In this case, there is a space before `export`.

   However, this method only works if the `HISTCONTROL` parameter is set to `ignorespace` or `ignoreboth` in the shell settings.

2. **Changing history settings temporarily:**
   - You can temporarily disable the saving of history in your terminal by executing:
     ```bash
     set +o history
     export GIT_TOKEN=YOUR_TOKEN
     set -o history
     ```
     This will disable command logging for the duration of your current terminal session.