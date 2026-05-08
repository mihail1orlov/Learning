# Portainer — install & first stack

[Portainer](https://www.portainer.io/) is a web UI for Docker. Useful when you'd rather click through containers than type `docker ps -a` six times.

## 1. Install

Make sure Docker is installed and running, then start Portainer as a container:

```bash
sudo docker run -d \
    -p 9000:9000 \
    --name=portainer \
    --restart=unless-stopped \
    -v /var/run/docker.sock:/var/run/docker.sock \
    -v portainer_data:/data \
    portainer/portainer
```

Browse to `http://localhost:9000` (or `http://<host>:9000` from another machine).

## 2. First-run setup

- Create the admin user when prompted.
- Pick **Local** as the Docker environment and click **Connect**. (Portainer talks to Docker through the mounted `/var/run/docker.sock`.)

## 3. Deploy a stack

Stacks are Portainer's wrapper for `docker-compose`.

1. Sidebar → **Stacks** → **Add Stack**.
2. Give it a name (e.g. `mariadb-stack`).
3. Paste your `docker-compose.yml` into the **Web editor** field.
4. Click **Deploy the stack**.

Portainer composes it up, and the containers appear under **Containers** with the stack tag attached for easy filtering.
