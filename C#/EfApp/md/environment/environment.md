
# Setting Up Development on Windows PC with Hyper-V, Ubuntu VM, and Docker

This document outlines the steps for setting up a development environment.

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

## Step 3: Creating a Docker Image with MySQL
1. **Download the MySQL image**:
   ```
   docker pull mysql
   ```
2. **Create a MySQL container**:
   ```
   docker run --name mysql-container -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql
   ```

## Step 4: Connecting to MySQL from Visual Studio
1. **Find out the MySQL container's IP address** in Docker.
2. **Use this IP address to connect** to MySQL from Visual Studio.

## Additional Tips:
- **Install Docker Compose** if necessary.
- **Configure ports** for the MySQL Docker container.
- **Use Docker Volume** to persist data.

## Note:
- Check the network interaction between the Windows PC and the Ubuntu VM.

[Go back](../../main.md#environment)