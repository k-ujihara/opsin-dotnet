rem Before execute it, see the instruction in `README.md`.

set HERE=%~dp0.

echo Set `JDK1.8_HOME` envirnment variable.
where /Q javac
if errorlevel 1 goto :MISSING_JAVAC
for /F "usebackq tokens=*" %%i in (`where javac`) do set JDK1.8_HOME=%%i
set JDK1.8_HOME=%JDK1.8_HOME:javac.exe=%
set JDK1.8_HOME=%JDK1.8_HOME%..

echo Check NAnt is installed.
where /Q nant
if errorlevel 1 path %HERE%\nant-0.92\bin;%Path%
where /Q nant
if errorlevel 1 goto :MISSING_NANT

echo Build IKVM.
where /Q ikvmc
if %errorlevel% equ 0 goto :END_IKVM_BUILD
if exist %HERE%\ikvm8\bin\ikvmc.exe goto :ADD_IKVM_TO_PATH
if exist %HERE%\ikvm8\bin\ICSharpCode.SharpZipLib.dll goto :SharpZipLibAdded
if not exist %HERE%\sharpziplib.1.3.1\lib\net45\ICSharpCode.SharpZipLib.dll goto :MISSINGSharpZipLib
copy /Y %HERE%\sharpziplib.1.3.1\lib\net45\ICSharpCode.SharpZipLib.dll %HERE%\ikvm8\bin\
:SharpZipLibAdded
if not exist %HERE%\ikvm.windward.8.5.0.3\lib\*.* goto :MISSINGIKVMDLL
pushd %HERE%\ikvm8
nant
if errorlevel 1 goto :ERROREND
rem Replace DLLs by DLLs in NuGet package and rebuild it in order to build ikvmc for singed assembly.
copy /Y %HERE%\ikvm.windward.8.5.0.3\lib\*.* %HERE%\ikvm8\bin\
cd bin
del /Q ikvm.exe ikvmc.exe ikvmstub.exe
cd ..
cd ikvm
nant
if errorlevel 1 goto :ERROREND
cd ..
cd ikvmstub
nant
if errorlevel 1 goto :ERROREND
cd ..
cd ikvmc
nant
if errorlevel 1 goto :ERROREND
cd ..
popd
:ADD_IKVM_TO_PATH
path %HERE%\ikvm8\bin;%Path%
:END_IKVM_BUILD

echo Build opsin-2.5.0-jar-with-dependencies.dll.
ikvmc -target:library opsin-2.5.0-jar-with-dependencies.jar

echo opsin-2.5.0-jar-with-dependencies.dll is created in %HERE%.

goto :END

:MISSING_JAVAC
echo javac is missing.
exit /B 1
:MISSING_NANT
echo nant is missing.
exit /B 1
:MISSINGSharpZipLib
echo SharpZipLib is missing.
exit /B 1
:MISSINGIKVMDLL
echo You need to unpack ikvm.windward.8.5.0.3.nuget.
:ERROREND
echo Something error hhappened.
exit /B 1

:END
