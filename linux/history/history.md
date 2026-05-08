# Hiding commands from shell history

Two tricks for keeping a sensitive command (e.g. one that includes a token) out of `~/.bash_history`.

## 1. Lead with a space

In most shell setups, commands that begin with a space are not saved:

```bash
 export GIT_TOKEN=YOUR_TOKEN
```

Note the leading space before `export`. This only works when `HISTCONTROL` is set to `ignorespace` or `ignoreboth`:

```bash
echo $HISTCONTROL
# ignoreboth   ← good
```

If it's not set, add this to `~/.bashrc`:

```bash
export HISTCONTROL=ignoreboth
```

## 2. Disable history for the current shell

Toggle history off, run the sensitive command, toggle it back on:

```bash
set +o history
export GIT_TOKEN=YOUR_TOKEN
set -o history
```

This affects only the current shell session. Anything you do between the two `set` lines is invisible to history.
