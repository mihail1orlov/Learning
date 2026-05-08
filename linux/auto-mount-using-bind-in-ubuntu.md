# Auto-mount with `bind` in Ubuntu

A bind mount makes one directory appear at a second path. Adding it to `/etc/fstab` makes the mapping survive reboots — handy for exposing a deeply-nested data folder somewhere convenient (e.g. `/home/user/photos` → `/srv/photos`).

## Steps

1. **Make sure the destination exists**:

   ```bash
   sudo mkdir -p /path/destination
   ```

2. **Edit fstab**:

   ```bash
   sudo nano /etc/fstab
   ```

3. **Append** a bind line — source first, destination second:

   ```
   /path/source /path/destination none bind 0 0
   ```

4. **Test without rebooting**:

   ```bash
   sudo mount -a
   ```

   If `mount -a` is silent, you're good. If it complains, fix the typo before rebooting — a broken `fstab` will land you in emergency mode.

5. **Reboot** to confirm the mount comes back up automatically.

## Notes

- The `none` filesystem column is a placeholder — bind mounts don't have a "type".
- The two zeros at the end disable dump and fsck for this entry.
- For a one-off (non-persistent) bind: `sudo mount --bind /path/source /path/destination`.
