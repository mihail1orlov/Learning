# Development environment

Setting up Time Tracker on a Windows host: Hyper-V → Ubuntu VM → Docker → Portainer → MariaDB → HeidiSQL on the host as the desktop client.

## 1. Hyper-V + Ubuntu VM

1. Enable Hyper-V (*Programs and Features* → *Turn Windows features on or off* → *Hyper-V*).
2. Create a new VM and install Ubuntu Server (or Desktop, your call).

## 2. Docker on Ubuntu

In the VM:

```bash
sudo apt update
sudo apt install docker.io
sudo systemctl enable --now docker
```

## 3. Portainer

[Portainer](https://www.portainer.io/) is a web UI for Docker. Run it as a container itself:

```bash
sudo docker run -d \
    -p 9000:9000 \
    --name=portainer \
    --restart=unless-stopped \
    -v /var/run/docker.sock:/var/run/docker.sock \
    -v portainer_data:/data \
    portainer/portainer
```

Open `http://<vm-ip>:9000` in a browser, create the admin user, choose the *Local* environment.

See [Portainer setup](portainer-docker-image/portainer-docker-image.md) for a step-by-step tour.

## 4. MariaDB via a Portainer Stack

In Portainer → **Stacks → Add Stack**, paste this `docker-compose.yml` into the *Web editor*:

```yaml
version: '3.1'

services:
  mariadb:
    image: mariadb
    container_name: time_tracker_mariadb
    restart: always
    environment:
      MYSQL_ROOT_PASSWORD: my-secret-pw
      MYSQL_DATABASE: mydatabase
    ports:
      - "3306:3306"
    volumes:
      - mariadb_data:/var/lib/mysql

volumes:
  mariadb_data:
```

Click *Deploy the stack*.

## 5. Verify

In Portainer → **Containers**, confirm `time_tracker_mariadb` is running. To check the actual MariaDB version (handy if you want to pin it later):

```bash
docker exec time_tracker_mariadb mariadb --version
```

For production-ish work, replace `mariadb` with a pinned tag (e.g. `mariadb:11.3`) in the compose file so updates don't surprise you.

## 6. HeidiSQL on the Windows host

[HeidiSQL](https://www.heidisql.com/) is a friendly desktop client for MySQL/MariaDB. Connect from Windows to the MariaDB running inside the Ubuntu VM.

See [HeidiSQL setup](heidi-sql/heidi-sql.md) for the connection settings.
