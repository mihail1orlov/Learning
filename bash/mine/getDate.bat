REM Set current working-directory to where the bat-file is.
SET mypath=%~dp0
cd "%mypath:~0,-1%"

REM Create directory
for /f "skip=1" %%i in ('wmic os get localdatetime') do if not defined fulldate set fulldate=%%i
set year=%fulldate:~0,4%
set month=%fulldate:~4,2%
set day=%fulldate:~6,2%
set foldername=%year%%month%%day%
mkdir "%foldername%"