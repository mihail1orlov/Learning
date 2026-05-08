# Nextcloud

A handful of `occ` commands that I keep needing when running Nextcloud in Docker.

## Rescan files

If files appear on disk but not in the UI, rescan them for every user:

```bash
docker exec -u 33 7883d php occ files:scan --all
```

`33` is the `www-data` UID inside the official image; `7883d` is the container ID — replace as needed.

## Reset the admin password

```bash
docker exec -u www-data -it nextcloud_main php occ user:resetpassword admin
```

## Bind-mount a host directory into the container's data path

For mounting a different volume into Nextcloud's `data/` path on the host (not inside the container):

```bash
sudo mount --bind /path/to/source /path/to/destination
sudo umount /path/to/destination
```

To make it persistent, see [`auto-mount-using-bind-in-ubuntu.md`](auto-mount-using-bind-in-ubuntu.md).
