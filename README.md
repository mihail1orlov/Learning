# Learning

> A long-running pile of code I wrote while learning new things.
> Some folders are tutorials I followed. Some are little experiments I started and never finished. Some are notes I keep so I don't have to google the same thing twice.
>
> _It's a sandbox. Take what's useful, ignore the rest._

## Map

Browse any folder — each one has its own `README.md`.

### Languages & frameworks

| | | |
| --- | --- | --- |
| [**C#**](csharp) — small `.NET` solutions, big shelf | [**Blazor**](blazor) — server-side Blazor sandbox | [**Angular**](angular) — components, tabs, RxJS |
| [**React**](react) — CRA scaffold | [**TypeScript**](typescript) — minimal `tsc` setup | [**HTML**](html) — Flexbox / Grid practice |

### Backend & infrastructure

| | | |
| --- | --- | --- |
| [**Docker**](docker) — containers, compose, TeamCity | [**RabbitMQ**](rabbitmq) — pub/sub with Protobuf | [**Kafka**](kafka) — Confluent .NET client |
| [**TimescaleDB**](timescaledb) — time-series on Postgres | [**Linux**](linux) — Ubuntu / KVM / networking | [**Bash**](bash) — shell + batch one-liners |

### Embedded & extensions

| | | |
| --- | --- | --- |
| [**Arduino**](arduino) — classic Blink | [**ESP8266**](esp8266) — Wi-Fi sketches, Telegram bot | [**Edge Extensions**](edge-extensions) — MV3 starter |

### Windows toolbox

| | | |
| --- | --- | --- |
| [**Windows**](windows) — multi-RDP patch | [**PowerShell**](powershell) — cmdlet snippets | [**diskpart**](diskpart) — partition recipes |
| [**regedit**](regedit) — auto-login, auto-run | [**Moonlight**](moonlight) — game-streaming ports | |

### Notes & references

| | | |
| --- | --- | --- |
| [**Git**](git) — PAT auth, commit conventions | [**Markdown**](markdown) — Mermaid, PlantUML, KaTeX | [**Jupyter**](jupyter) — math, geo, surfaces |
| [**AI**](ai) — image-gen links | | |

---

## Quick wins

A few snippets I keep coming back to:

```bash
# Burn an Ubuntu ISO to a USB stick
sudo dd bs=4M if=path/to/ubuntu.iso of=/dev/sdb status=progress oflag=sync
```

```bash
# WireGuard, the short version: see linux/wireguard.md
```

```ps1
# Allow multiple concurrent RDP sessions: see windows/enable-multiple-remote-desktop-sessions/
```

---

_Don't take anything in here too seriously — it's a draft of a draft of a draft._
