# Patch the Termsrv.dll to Enable Multiple Remote Desktop Sessions

[go back](../../README.md#bootable-usb-stick-on-linux)

This guide was adapted from [Windows OS Hub](https://woshub.com/how-to-allow-multiple-rdp-sessions-in-windows-10/) for enabling multiple concurrent Remote Desktop sessions on Windows by editing the `termsrv.dll` file. The complete instructions and references can be found on that page.

## Патч для Termsrv.dll для ввімкнення кількох сеансів віддаленого робочого столу (RDP)

Щоб зняти обмеження на кількість одночасних підключень RDP у Windows без використання RDP Wrapper, ви можете замінити оригінальний файл `termsrv.dll`. Це основна бібліотека, яку використовує служба віддаленого робочого столу. Файл знаходиться у каталозі `C:\Windows\System32`.

## Кроки для заміни `termsrv.dll`

1. **Створення резервної копії**: Перед редагуванням або заміною створіть резервну копію файлу, щоб можна було повернутись до оригінальної версії у разі необхідності. Використайте команду в підвищеному командному рядку:

   ```bash
   copy c:\Windows\System32\termsrv.dll termsrv.dll_backup
   ```

2. **Взяття права власності**: Змініть власника файлу з TrustedInstaller на локальну групу адміністраторів:

   ```bash
   takeown /F c:\Windows\System32\termsrv.dll /A
   ```

3. **Надання дозволів**: Використайте інструмент `icacls.exe`, щоб надати групі адміністраторів повний контроль:

   ```bash
   icacls c:\Windows\System32\termsrv.dll /grant Administrators:F
   ```

4. **Зупинка служби віддаленого робочого столу**: Зупиніть службу віддаленого робочого столу за допомогою консолі `services.msc` або виконайте команду:

   ```bash
   net stop TermService
   ```

5. **Редагування файлу**: Відкрийте файл `termsrv.dll` у HEX-редакторі (наприклад, Tiny Hexer). В залежності від версії Windows, знайдіть та замініть рядки згідно з таблицею нижче:

    | **Windows Build**       | **Find the String**                                | **Replace with**                            |
    |-------------------------|----------------------------------------------------|---------------------------------------------|
    | Windows 11 22H2         | `39 81 3C 06 00 00 0F 84 75 7A 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 22H2         | `39 81 3C 06 00 00 0F 84 85 45 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 11 21H2 (RTM)   | `39 81 3C 06 00 00 0F 84 4F 68 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 21H2     | `39 81 3C 06 00 00 0F 84 DB 61 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 21H1     | `39 81 3C 06 00 00 0F 84 2B 5F 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 20H2     | `39 81 3C 06 00 00 0F 84 21 68 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 2004     | `39 81 3C 06 00 00 0F 84 D9 51 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 1909     | `39 81 3C 06 00 00 0F 84 5D 61 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 1903     | `39 81 3C 06 00 00 0F 84 5D 61 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 1809     | `39 81 3C 06 00 00 0F 84 3B 2B 01 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 1803     | `8B 99 3C 06 00 00 8B B9 38 06 00 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |
    | Windows 10 x64 1709     | `39 81 3C 06 00 00 0F 84 B1 7D 02 00`              | `B8 00 01 00 00 89 81 38 06 00 00 90`      |

6. **Перезапуск служби**: Після редагування файлу запустіть службу віддаленого робочого столу

   ```bash
   net start TermService
   ```

### Якщо виникли проблеми

Якщо щось пішло не так, зупиніть службу і замініть змінений файл на оригінальний:

   ```bash
   copy termsrv.dll_backup c:\Windows\System32\termsrv.dll
   ```
