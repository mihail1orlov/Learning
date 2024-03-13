# Bootable USB stick on Linux
[Ukrainian version of the page](bootable-usb-stick-on-linux_ukr.md)

[to main](../README.md#bootable-usb-stick-on-linux)

To create a bootable Ubuntu USB stick on Kali Linux, you'll need an Ubuntu ISO image and a USB stick. Here are two main methods for creating a bootable USB stick: through the command line and using a graphical interface.

### Creating via Command Line

1. **Preparation:**
   - Connect your USB stick.
   - Open a terminal and use the command `lsblk` or `sudo fdisk -l` to identify your USB stick (e.g., /dev/sdb).

2. **Unmount the USB Stick:**
   - If the stick is automatically mounted, unmount it using the command `sudo umount /dev/sdb1` (replace sdb1 with your identifier).

3. **Writing the Image:**
   - Use the `dd` command to write the image to the USB stick:
     ```
     sudo dd bs=4M if=path/to/ubuntu.iso of=/dev/sdb status=progress oflag=sync
     ```
   - Replace `path/to/ubuntu.iso` with the path to your ISO file and `/dev/sdb` with the identifier of your USB stick without the partition number (e.g., use /dev/sdb, not /dev/sdb1).