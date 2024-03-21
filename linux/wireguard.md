# WireGuard VPN Configuration Guide

[go back](linux.md#wireguard-vpn-configuration-guide)

This guide provides an overview of configuring a WireGuard VPN peer with a focus on ensuring a stable and persistent connection. We will cover the critical aspect of setting up the `PersistentKeepalive` option, which is particularly useful for maintaining connectivity through NAT (Network Address Translation).

## Overview

WireGuard is a modern, high-performance VPN designed to be easy to use while providing robust security. One of its configuration options, `PersistentKeepalive`, sends periodic keepalive packets to maintain the connection. This feature is crucial for connections through NAT, helping to prevent the connection from being dropped due to inactivity.

## Configuration Steps

To configure a WireGuard peer to use `PersistentKeepalive`, follow these steps. This guide assumes you have already installed WireGuard and have basic knowledge of editing configuration files.

### 1. Locate Your WireGuard Configuration File

WireGuard configuration files are typically located in `/etc/wireguard/`. Each VPN interface has its own configuration file, named after the interface, such as `wg0.conf`.

```bash
cd /etc/wireguard
ls
```

### 2. Edit the Configuration File

Open the configuration file for your WireGuard interface using a text editor. If your interface is `wg0`, the file would be `wg0.conf`.

```bash
sudo nano /etc/wireguard/wg0.conf
```

### 3. Add or Modify the Peer Configuration

Within the configuration file, locate the `[Peer]` section corresponding to the peer you wish to configure. If you're setting up a new peer, you can add a new `[Peer]` section.

Here's what you should include in the peer configuration:

- `PublicKey`: The public key of the peer. This is required for establishing a secure connection.
- `AllowedIPs`: Defines which IP addresses should be routed through the VPN connection. Use `0.0.0.0/0` for all IPv4 traffic, or specify specific IP ranges.
- `PersistentKeepalive`: This option sets the interval, in seconds, at which keepalive packets are sent. A common setting is `25` seconds. If this line is missing, add it.

Example configuration:

```ini
[Peer]
PublicKey = examplePublicKey12345=
AllowedIPs = 0.0.0.0/0
PersistentKeepalive = 25
```

### 4. Save the Configuration File

After adding or modifying the peer configuration, save the file and exit the text editor.

### 5. Apply the Configuration

To apply the changes, restart the WireGuard interface. Replace `wg0` with the name of your WireGuard interface if different.

```bash
sudo wg-quick down wg0
sudo wg-quick up wg0
```

## Conclusion

You have successfully configured a WireGuard peer with `PersistentKeepalive` to maintain a stable connection, especially useful in NAT scenarios. This setting ensures that your VPN connection remains active by sending keepalive packets at regular intervals.

For more detailed information on configuring WireGuard and troubleshooting, refer to the [official WireGuard documentation](https://www.wireguard.com/).
```

This Markdown guide provides the essential steps to configure the `PersistentKeepalive` option for a WireGuard VPN peer, ensuring better connectivity through NAT environments.