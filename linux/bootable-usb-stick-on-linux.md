# Bootable USB stick on Linux

Two ways to write an Ubuntu ISO to a USB stick on a Linux host: the command line, and a graphical tool.

## Command line

1. **Identify the stick.** Plug it in and find its device node:

   ```bash
   lsblk
   # or
   sudo fdisk -l
   ```

   It will look like `/dev/sdb` (use the whole-disk node, **not** a partition like `/dev/sdb1`).

2. **Unmount it** if your DE auto-mounted it:

   ```bash
   sudo umount /dev/sdb1
   ```

3. **Write the ISO** with `dd`:

   ```bash
   sudo dd bs=4M if=path/to/ubuntu.iso of=/dev/sdb status=progress oflag=sync
   ```

   - Replace `path/to/ubuntu.iso` and `/dev/sdb` for your case.
   - `bs=4M` sets the read/write block size to 4 MiB. Larger blocks mean fewer I/O syscalls and usually faster transfer at the cost of a bit more RAM. `4M` is a sane default for modern flash drives.
   - `oflag=sync` flushes after every block so progress is real.

4. **Verify** the stick boots in your target machine.

## Graphical tools

If `dd` feels too sharp, any of these will do the same thing with a UI:

- [balenaEtcher](https://www.balena.io/etcher/) — cross-platform, opinionated, hard to misuse.
- [Ventoy](https://www.ventoy.net/) — install once, then drop multiple ISOs on the stick and pick at boot.
- [Rufus](https://rufus.ie/) — Windows-only, but worth mentioning if you ever switch hosts.
