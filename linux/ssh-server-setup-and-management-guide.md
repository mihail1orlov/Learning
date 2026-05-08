# SSH server — install, manage, key-auth

Set up OpenSSH on a Linux host and switch from password to key-based login.

## Install

```bash
sudo apt install openssh-server
```

## Service control

```bash
# Status (press `q` to exit)
sudo systemctl status ssh

# Stop and disable (boot won't start it)
sudo systemctl disable --now ssh

# Start and enable on boot
sudo systemctl enable --now ssh
```

## Firewall

If you use `ufw`:

```bash
sudo ufw allow ssh        # opens 22/tcp
# or, for a custom port:
sudo ufw allow 6576/tcp
```

## Key-based authentication

1. **Generate a key pair** on the client (skip if you already have one):

   ```bash
   ssh-keygen -t ed25519       # modern; or `-t rsa -b 4096` for legacy hosts
   ```

2. **Copy the public key** to the server:

   ```bash
   ssh-copy-id -i ~/.ssh/id_ed25519 user@77.134.54.101 -p 6576
   ```

3. **Verify** the connection uses the key (it should not prompt for a password):

   ```bash
   ssh user@77.134.54.101 -p 6576
   ```

## Hardening (optional, recommended)

Edit `/etc/ssh/sshd_config` on the server, then `sudo systemctl restart ssh`:

```
PasswordAuthentication no
PermitRootLogin no
```

Make sure key login works *before* you flip `PasswordAuthentication` to `no`, or you'll lock yourself out.
