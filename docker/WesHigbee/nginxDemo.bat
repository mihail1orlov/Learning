: create dir
mkdir NginxDemo

: change directory
cd NginxDemo

: create index.html file
(echo Hello, new nginx index.html file) > index.html

: create Dockerfile
@echo docker run --rm -d --name my-nginx -p 8080:80 nginx
@echo docker cp %cd%\index.html my-nginx:/usr/share/nginx/html/index.html
@echo docker commit my-nginx my-nginx:nginx

(echo FROM nginx && echo COPY index.html /usr/share/nginx/html/index.html) > Dockerfile

: docker
docker build -f Dockerfile -t my-nginx .
start http://localhost:8080/
docker run --rm --name my-nginx -p 8080:80 my-nginx