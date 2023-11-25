# Connecting to MySQL Server in Docker using HeidiSQL 
`HeidiSQL` is a popular database management client, including MySQL, that works on Windows. To connect to your MySQL server deployed in a Docker container on Ubuntu VM via HeidiSQL, follow these steps:
- Use port `3306` to connect to MariaDB.
- Use the provided credentials (`MYSQL_ROOT_PASSWORD`, `MYSQL_DATABASE`) to access the database.
[HeidiSQL page](heidi-sql/heidi-sql.md)

## Step 1: Find Out the IP Address of the Ubuntu VM
Determine the IP address of your Ubuntu VM where Docker is running. This can be done by executing the `ip a` command in the Ubuntu terminal.

## Step 2: Check the Availability of the MySQL Port
Ensure that the MySQL port (default 3306) is open and forwarded from the Docker container to the Ubuntu VM host system. When creating the container, use the `-p` parameter, for example:
```bash
docker run --name mysql-container -e MYSQL_ROOT_PASSWORD=my-secret-pw -p 3306:3306 -d mysql
```

## Step 3: Setting Up HeidiSQL
Open HeidiSQL and click on "New" to create a new connection.
Enter the following connection details:
- **Network type**: Select `MySQL (TCP/IP)`.
- **Hostname / IP**: Enter the IP address of your Ubuntu VM.
- **User**: Enter the MySQL username (e.g., `root`).
- **Password**: Enter the password you specified when creating the Docker container (e.g., `my-secret-pw` in the example).
- **Port**: Ensure that the port is set to `3306` (or another, if you have changed it).

## Step 4: Connection
Click 'Save' to save the connection settings.
Click 'Open' to connect to the MySQL server.

### Note:
If there are network restrictions between your Windows PC and the Ubuntu VM, ensure that the connection is allowed through the firewall or other network settings.

[Go back](../environment.md#step-6-connecting-to-mysql-server-in-docker-using-heidisql)