// refresh the files for all users
docker exec -u 33 7883d php occ files:scan --all
docker exec -u www-data -it nextcloud_main php occ user:resetpassword admin

sudo mount --bind /путь/к/исходной/директории /путь/к/целевой/директории
sudo umount /путь/к/целевой/директории