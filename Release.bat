C:\Factory\Tools\RDMD.exe /RC out

COPY /B AccessLamp\AccessLamp\bin\Release\AccessLamp.exe out
COPY /B icon\* out
COPY /B doc\* out

rem C:\Factory\Tools\zcp.exe out C:\app\AccessLamp
rem COPY out\AccessLamp.exe C:\app\AccessLamp\.

C:\Factory\SubTools\zip.exe /O out AccessLamp

IF NOT "%1" == "/-P" PAUSE
