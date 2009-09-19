@ECHO off

SET AutoVer=AutoVersioning\AutoVersioning.exe
SET SolnDir=..\..\
SET BaseVersion=1 1

IF NOT EXIST %AutoVer% (
	ECHO ERROR %AutoVer% not found.
	GOTO :Done
)

%AutoVer% "%SolnDir%JsonFx.BuildTools\Properties\AssemblyVersion.cs" %BaseVersion%

%AutoVer% "%SolnDir%JsonFx.Client\Properties\AssemblyVersion.cs" %BaseVersion%

%AutoVer% "%SolnDir%JsonFx.History\Properties\AssemblyVersion.cs" %BaseVersion%

%AutoVer% "%SolnDir%JsonFx.IO\Properties\AssemblyVersion.cs" %BaseVersion%

%AutoVer% "%SolnDir%JsonFx.Json\Properties\AssemblyVersion.cs" %BaseVersion%

%AutoVer% "%SolnDir%JsonFx.UI\Properties\AssemblyVersion.cs" %BaseVersion%

:Done
PAUSE