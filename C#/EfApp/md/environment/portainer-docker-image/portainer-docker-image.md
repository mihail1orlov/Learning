# Portainer Installation and Setup Guide

- [Portainer Installation and Setup Guide](#portainer-installation-and-setup-guide)
  - [Step 1: Installing Portainer](#step-1-installing-portainer)
  - [Step 2: Configuring Portainer](#step-2-configuring-portainer)
  - [Step 3: Using Portainer to Manage Docker](#step-3-using-portainer-to-manage-docker)

## Step 1: Installing Portainer
- **Ensure that Docker is installed and running** on your computer.
- **Launch Portainer** using the following command:
  ```
  sudo docker run -d -p 9000:9000 --name=portainer --restart=unless-stopped -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer
  ```
- **Open Portainer** by navigating to `http://localhost:9000` in your browser.

## Step 2: Configuring Portainer
- **Create a user**: On the first launch, Portainer will ask you to create an administrator user.
- **Connect Portainer to Docker**: Select "Local" as the Docker environment and click "Connect".

## Step 3: Using Portainer to Manage Docker
- **On the main page of Portainer**, select "Stacks".
- **Create a new Stack**:
  - Click "Add Stack".
  - Enter a name for the Stack, for example, `mariadb-stack`.
  - In the "Web editor" field, paste the contents of your `docker-compose.yml` file.
  - Click "Deploy the stack".

[Go back](../environment.md#step-3-creating-a-portainer-docker-image)