
# Setting Up Development on Windows PC with Hyper-V, Ubuntu VM, and Docker

This document outlines the steps for setting up a development environment.

- [Setting Up Development on Windows PC with Hyper-V, Ubuntu VM, and Docker](#setting-up-development-on-windows-pc-with-hyper-v-ubuntu-vm-and-docker)
  - [Step 1: Setting Up Hyper-V and Ubuntu VM](#step-1-setting-up-hyper-v-and-ubuntu-vm)
  - [Step 2: Installing Docker in Ubuntu](#step-2-installing-docker-in-ubuntu)
  - [Step 3: Creating a Portainer Docker Image](#step-3-creating-a-portainer-docker-image)
  - [Step 4: Launching MariaDB Using Portainer](#step-4-launching-mariadb-using-portainer)
  - [Step 5: Checking and Management](#step-5-checking-and-management)
  - [Step 6: Connecting to MySQL Server in Docker using HeidiSQL](#step-6-connecting-to-mysql-server-in-docker-using-heidisql)

## Step 1: Setting Up Hyper-V and Ubuntu VM
1. **Enable Hyper-V** through "Programs and Features".
2. **Create and install an Ubuntu VM**.

## Step 2: Installing Docker in Ubuntu
1. **Open the Ubuntu VM terminal**.
2. **Install Docker**:
   ```
   sudo apt update
   sudo apt install docker.io
   ```
3. **Start Docker**:
   ```
   sudo systemctl start docker
   sudo systemctl enable docker
   ```

## Step 3: Creating a Portainer Docker Image
   ```
sudo docker run -d -p 9000:9000 --name=portainer --restart=unless-stopped -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer
   ```
[Portainer page](portainer-docker-image/portainer-docker-image.md)

## Step 4: Launching MariaDB Using Portainer
- Follow the instructions for using Portainer to create a new stack.
- Use the following configuration in the "Web editor":

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

## Step 5: Checking and Management
- After deploying the stack, go to the "Containers" section in Portainer.
- Find the `time_tracker_mariadb` container in the list and check its status.

For greater reliability, I recommend finding out the version of MariaDB and using a fixed version, updating only when necessary.

   ```
docker exec time_tracker_mariadb mariadb --version
   ```

## Step 6: Connecting to MySQL Server in Docker using HeidiSQL 
`HeidiSQL` is a popular database management client, including MySQL, that works on Windows. To connect to your MySQL server deployed in a Docker container on Ubuntu VM via HeidiSQL, follow these steps:
- Use port `3306` to connect to MariaDB.
- Use the provided credentials (`MYSQL_ROOT_PASSWORD`, `MYSQL_DATABASE`) to access the database.  
[HeidiSQL page](heidi-sql/heidi-sql.md)

[Go back](../../main.md#environment)