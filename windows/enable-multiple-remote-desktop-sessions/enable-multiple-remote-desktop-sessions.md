# Patch `termsrv.dll` to enable multiple concurrent RDP sessions

By default Windows allows only one Remote Desktop session at a time. The standard workaround is [RDP Wrapper](https://github.com/stascorp/rdpwrap), but it is brittle on every Windows update. The lower-level alternative is to patch `C:\Windows\System32\termsrv.dll` directly — the DLL that the Remote Desktop service loads.

> Adapted from [Windows OS Hub](https://woshub.com/how-to-allow-multiple-rdp-sessions-in-windows-10/). Read that page for the up-to-date byte sequences for newer Windows builds.

## Caveats before you start

- This modifies a system file. **Make a backup first.**
- The patched DLL is build-specific: a Windows update will replace it and you'll need to redo the patch.
- This is not supported by Microsoft. Don't do it on machines where licensing matters.

## Steps

Run an elevated `cmd.exe` (Run as Administrator) for everything below.

### 1. Back up the original DLL

```cmd
copy C:\Windows\System32\termsrv.dll termsrv.dll_backup
```

Keep the backup somewhere safe outside `System32`.

### 2. Take ownership of the file

`TrustedInstaller` owns it by default. Reassign ownership to the local Administrators group:

```cmd
takeown /F C:\Windows\System32\termsrv.dll /A
```

### 3. Grant the Administrators group full control

```cmd
icacls C:\Windows\System32\termsrv.dll /grant Administrators:F
```

### 4. Stop the Remote Desktop service

Either via `services.msc`, or:

```cmd
net stop TermService
```

### 5. Patch the DLL with a hex editor

Open `C:\Windows\System32\termsrv.dll` in any hex editor (e.g. [HxD](https://mh-nexus.de/en/hxd/), Tiny Hexer). Find the byte pattern that matches your Windows build and replace it with the second column.

| Windows build         | Find                                       | Replace with                         |
| --------------------- | ------------------------------------------ | ------------------------------------ |
| Windows 11 22H2       | `39 81 3C 06 00 00 0F 84 75 7A 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 22H2       | `39 81 3C 06 00 00 0F 84 85 45 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 11 21H2 (RTM) | `39 81 3C 06 00 00 0F 84 4F 68 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 21H2   | `39 81 3C 06 00 00 0F 84 DB 61 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 21H1   | `39 81 3C 06 00 00 0F 84 2B 5F 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 20H2   | `39 81 3C 06 00 00 0F 84 21 68 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 2004   | `39 81 3C 06 00 00 0F 84 D9 51 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 1909   | `39 81 3C 06 00 00 0F 84 5D 61 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 1903   | `39 81 3C 06 00 00 0F 84 5D 61 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 1809   | `39 81 3C 06 00 00 0F 84 3B 2B 01 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 1803   | `8B 99 3C 06 00 00 8B B9 38 06 00 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|
| Windows 10 x64 1709   | `39 81 3C 06 00 00 0F 84 B1 7D 02 00`      | `B8 00 01 00 00 89 81 38 06 00 00 90`|

If your build isn't in the table, check the Windows OS Hub article for an updated list. There's also a related batch script: [`bash/update_termsrv.bat`](../../bash/update_termsrv.bat).

### 6. Restart the service

```cmd
net start TermService
```

You should now be able to open multiple concurrent RDP sessions.

## If something breaks

Stop the service and restore the original DLL from your backup:

```cmd
net stop TermService
copy termsrv.dll_backup C:\Windows\System32\termsrv.dll
net start TermService
```
