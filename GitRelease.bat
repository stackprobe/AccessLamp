IF NOT EXIST .\GitRelease.bat GOTO END
CALL qq
C:\Factory\SubTools\GitFactory.exe /ow . C:\home\GitHub\AccessLamp
rem CALL C:\var\go.bat
:END
