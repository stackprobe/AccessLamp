C:\Factory\Tools\RDMD.exe /RC out

COPY /B AccessLamp2\AccessLamp2\bin\Release\AccessLamp2.exe out
COPY /B ..\..\icon\* out

rem C:\Factory\Tools\zcp.exe out C:\app\AccessLamp2
COPY out\AccessLamp2.exe C:\app\AccessLamp2\.

C:\Factory\SubTools\zip.exe /O out AccessLamp2

PAUSE
