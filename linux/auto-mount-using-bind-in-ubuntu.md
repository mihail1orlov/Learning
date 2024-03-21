# [Auto-Mount Using Bind in Ubuntu](auto-mount-using-bind-in-ubuntu.md)

This guide provides step-by-step instructions on how to automatically mount a directory using the `bind` option in Ubuntu after a system reboot. 

## Prerequisites

- Ubuntu system
- Terminal access
- Administrative (sudo) privileges

## Instructions

1. **Open Terminal:** Use your preferred method to open a terminal window.

2. **Create Mount Point:** Ensure the destination directory exists. If not, create it with:
   ```bash
   sudo mkdir -p /path/destination
   ```

3. **Edit fstab File:** Open the `/etc/fstab` file with root privileges using a text editor like nano:
   ```bash
   sudo nano /etc/fstab
   ```

4. **Add Bind Mount:** Append the following line to the end of the `fstab` file, replacing `/path/source` and `/path/destination` with your source and destination paths, respectively:
   ```
   /path/source /path/destination none bind 0 0
   ```
   This tells the system to automatically bind mount the source directory to the destination directory at startup.

5. **Save and Close:** Save your changes and close the text editor. If using nano, press `Ctrl+O` followed by `Enter` to save, then `Ctrl+X` to exit.

6. **Test the Configuration:** To ensure there are no errors in your fstab file and the mount can be performed successfully, run:
   ```bash
   sudo mount -a
   ```
   This command attempts to mount all filesystems specified in `fstab`.

7. **Reboot:** Optionally, reboot your system to confirm that the directory is automatically mounted on startup.