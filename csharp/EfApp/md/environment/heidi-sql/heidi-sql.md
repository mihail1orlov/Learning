# HeidiSQL — connect to MariaDB in Docker

[HeidiSQL](https://www.heidisql.com/) is a Windows desktop client for MySQL, MariaDB, PostgreSQL, and SQL Server. We use it to talk to the MariaDB container running in the Ubuntu VM.

## 1. Find the VM's IP address

Inside the Ubuntu VM:

```bash
ip a
```

Look for the IP on the bridge or NAT interface — typically something like `192.168.x.x`.

## 2. Confirm the MariaDB port is exposed

The container should publish `3306` on the host. If you used the compose stack from [environment.md](../environment.md), this is already done. To double-check:

```bash
docker ps --format '{{.Names}}\t{{.Ports}}'
```

You should see `0.0.0.0:3306->3306/tcp`. If you ever need to launch a one-off MariaDB without the stack:

```bash
docker run --name mysql-container \
    -e MYSQL_ROOT_PASSWORD=my-secret-pw \
    -p 3306:3306 \
    -d mariadb
```

## 3. New connection in HeidiSQL

Open HeidiSQL → **New** → fill in:

| Field          | Value                                       |
| -------------- | ------------------------------------------- |
| Network type   | `MySQL (TCP/IP)`                            |
| Hostname / IP  | The VM's IP from step 1                     |
| User           | `root` (or whatever you configured)         |
| Password       | `my-secret-pw` from your compose file       |
| Port           | `3306` (or your custom port)                |

Click **Save**, then **Open**.

## 4. If it doesn't connect

- Confirm the Windows host can reach the VM at all: `ping <vm-ip>`.
- Confirm the firewall (Windows + the VM's `ufw`/`iptables`) allows `3306`.
- Confirm the container's port mapping with `docker ps`.
- Check the MariaDB logs: `docker logs time_tracker_mariadb`.
