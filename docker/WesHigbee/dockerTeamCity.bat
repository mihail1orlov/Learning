: this file need to run in the powershell
set dir=TeamCityTmp
mkdir %dir%
cd %dir%

set fileName=docker-compose.yml
curl https://gist.githubusercontent.com/g0t4/fc6a7b62be5a14c5af9df42af2aa2b2b/raw/b9d2475d0cf96d576a355917cb8d6c7f42079539/docker-compose.yml -o %fileName%
cat %fileName%

docker-compose up
docker-compose down // remove network
docker network inspect teamcity_default
docker network inspect bridge // inspect main network

docker exec -it container bash
	or
docker-compose exec container bash