# SSH Server Setup and Management Guide

[to linux](linux.md#ssh-server-setup-and-management-guide)

- [SSH Server Setup and Management Guide](#ssh-server-setup-and-management-guide)
  - [Installing OpenSSH Server](#installing-openssh-server)
  - [Checking SSH Service Status](#checking-ssh-service-status)
  - [Managing SSH Service](#managing-ssh-service)
  - [Configuring Firewall](#configuring-firewall)
  - [Generating SSH Keys](#generating-ssh-keys)
  - [Copying the SSH Key to a Remote Server](#copying-the-ssh-key-to-a-remote-server)
  - [Verifying the Connection](#verifying-the-connection)
  - [Conclusion](#conclusion)


This guide provides instructions for installing, managing, and using an SSH server on a Linux-based system. SSH (Secure Shell) is a protocol used for securely accessing a remote computer.

## Installing OpenSSH Server

To install the OpenSSH server, open a terminal and run the following command:

```bash
sudo apt install openssh-server
```

## Checking SSH Service Status

After installation, you can check the status of the SSH service using:

```bash
sudo systemctl status ssh
```

To exit the status view, press `q`.

## Managing SSH Service

To stop the SSH service, use:

```bash
sudo systemctl disable --now ssh
```

To start the SSH service and enable it to start at boot, use:

```bash
sudo systemctl enable --now ssh
```

## Configuring Firewall

If you are using `ufw` (Uncomplicated Firewall), allow SSH connections with:

```bash
sudo ufw allow ssh
```

## Generating SSH Keys

Generate a new SSH key pair (if you don't already have one) with:

```bash
ssh-keygen -t rsa
```

Follow the prompts to choose a save location and a passphrase (optional).

## Copying the SSH Key to a Remote Server

To copy your public key to a remote server, use:

```bash
ssh-copy-id -i ~/.ssh/id_rsa user@77.134.54.101 -p 6576
```

Replace `user@77.134.54.101` with the username and IP address of your remote server. Change `6576` to your server's SSH port if it's different from the default (22).

## Verifying the Connection

After setting up, verify that you can connect to the remote server via SSH:

```bash
ssh user@77.134.54.101 -p 6576
```

Replace `user@77.134.54.101` and `6576` with your server's actual user, IP, and port.

## Conclusion

You have now installed and configured an SSH server, allowed it through the firewall, generated an SSH key pair, and copied the public key to a remote server for passwordless authentication. You can now securely access your remote server over SSH.
```

This markdown file provides a structured, step-by-step guide to installing and configuring an SSH server, including key management for secure remote access. Adjust the IP address, port, and user details according to your specific setup requirements.