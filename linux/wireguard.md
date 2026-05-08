# WireGuard VPN — `PersistentKeepalive`

A focused guide to one specific WireGuard setting: `PersistentKeepalive`. It keeps the tunnel alive when one peer sits behind a NAT, by sending small heartbeat packets at a fixed interval.

## Why it matters

NAT routers drop idle UDP "connections" after a minute or two. WireGuard is UDP, so without periodic traffic the NAT mapping disappears and the peer becomes unreachable. `PersistentKeepalive` solves that by sending a tiny packet every N seconds.

It's a per-peer option — only the side **behind** the NAT needs it.

## Sharing configs as QR codes

Mobile clients (iOS/Android) accept WireGuard configs scanned from a QR code. On a Linux host, install `qrencode` and pipe the config into it:

```bash
qrencode -t ansiutf8 < /etc/wireguard/wg0.conf
```

![qrencode output](img/qrencode.png)

## Setting up `PersistentKeepalive`

1. **Locate the config.** WireGuard configs live in `/etc/wireguard/`, one file per interface (`wg0.conf`, `wg1.conf`, …):

   ```bash
   ls /etc/wireguard
   ```

2. **Edit the file**:

   ```bash
   sudo nano /etc/wireguard/wg0.conf
   ```

3. **Add or update the `[Peer]` block** with these keys:

   - `PublicKey` — the peer's public key (required).
   - `AllowedIPs` — what gets routed through the tunnel. Use `0.0.0.0/0` for everything, or narrow it down.
   - `PersistentKeepalive` — interval in seconds. `25` is the canonical value: short enough to outpace any NAT timeout, long enough to be cheap.

   ```ini
   [Peer]
   PublicKey = examplePublicKey12345=
   AllowedIPs = 0.0.0.0/0
   PersistentKeepalive = 25
   ```

4. **Reapply** the interface:

   ```bash
   sudo wg-quick down wg0
   sudo wg-quick up wg0
   ```

That's it — the tunnel will now survive NAT timeouts. For everything else, the [official docs](https://www.wireguard.com/) are excellent.
