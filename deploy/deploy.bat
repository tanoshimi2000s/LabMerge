call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"

pushd %~dp0\..\
MSBuild src\LabMerge.sln /t:clean;rebuild /p:Configuration=Release;Platform="Any CPU"
if %ERRORLEVEL% neq 0 (
    echo failed to build LabMerge.sln
    exit 1
)

xcopy src\LabMerge\bin\Release\net5.0\*.exe bin\ /Y /I
xcopy src\LabMerge\bin\Release\net5.0\*.dll bin\ /Y /I
xcopy src\LabMerge\bin\Release\net5.0\LabMerge.runtimeconfig.json bin\ /Y /I
xcopy third-party bin\third-party /Y /I /E
copy LICENSE bin\LICENSE /Y
copy README.md bin\README.txt /Y

pushd bin
7z a ..\LabMerge.zip *

popd
popd