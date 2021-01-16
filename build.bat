rem Before execute it, see the instruction in `README.md`.

set HERE=%~dp0.
set NANT_DIR=%HERE%\nant-0.92
set IKVM_DIR=%HERE%\ikvm8
set SharpZipLib_DIR=%HERE%\sharpziplib.1.3.1
set IKVMWINWARD_DIR=%HERE%\ikvm.windward.8.5.0.3
set OPSIN_JAR=opsin-2.5.0-jar-with-dependencies.jar

pushd

echo Set `JDK1.8_HOME` envirnment variable.
where /Q javac
if errorlevel 1 goto :MISSING_JAVAC
for /F "usebackq tokens=*" %%i in (`where javac`) do set JDK1.8_HOME=%%i
set JDK1.8_HOME=%JDK1.8_HOME:javac.exe=%
set JDK1.8_HOME=%JDK1.8_HOME%..

echo Check NAnt is installed.
where /Q nant
if errorlevel 1 path %NANT_DIR%\bin;%Path%
where /Q nant
if errorlevel 1 goto :MISSING_NANT

echo Preparing to build IKVM.
where /Q ikvmc
if %errorlevel% equ 0 goto :END_IKVM_BUILD
if exist %IKVM_DIR%\bin\ikvmc.exe goto :ADD_IKVM_TO_PATH
if exist %IKVM_DIR%\bin\ICSharpCode.SharpZipLib.dll goto :SharpZipLibAdded
if not exist %SharpZipLib_DIR%\lib\net45\ICSharpCode.SharpZipLib.dll goto :MISSINGSharpZipLib
copy /Y %SharpZipLib_DIR%\lib\net45\ICSharpCode.SharpZipLib.dll %IKVM_DIR%\bin\
:SharpZipLibAdded
if not exist %IKVMWINWARD_DIR%\lib\*.* goto :MISSINGIKVMDLL

echo Building IKVM.
cd %IKVM_DIR%
nant
if errorlevel 1 goto :ERROREND
rem Replace DLLs by DLLs in NuGet package and rebuild it in order to build ikvmc referring signed assemblies.
copy /Y %IKVMWINWARD_DIR%\lib\*.* %IKVM_DIR%\bin\
cd %IKVM_DIR%\bin
del /Q ikvm.exe ikvmc.exe ikvmstub.exe
cd %IKVM_DIR%\kvm
nant
if errorlevel 1 goto :ERROREND
cd %IKVM_DIR%\ikvmstub
nant
if errorlevel 1 goto :ERROREND
cd %IKVM_DIR%\ikvmc
nant
if errorlevel 1 goto :ERROREND
popd
:ADD_IKVM_TO_PATH
path %IKVM_DIR%\bin;%Path%
:END_IKVM_BUILD

echo Building %OPSIN_JAR%.
ikvmc -target:library -keyfile:Opsin\Opsin.snk %OPSIN_JAR%
if errorlevel 1 goto :ERROREND
echo DLL of %OPSIN_JAR% is created in %HERE%.

where /Q msbuild
if errorlevel 1 goto :MISSING_VS
echo Building 
msbuild %HERE%\Opsin\Opsin.csproj /t:Build /p:Configuration=Release
if errorlevel 1 goto :ERROREND

nuget pack "Opsin.nuspec" -Prop Configuration=Release -IncludeReferencedProjects


goto :END

:MISSING_JAVAC
echo javac is missing.
goto :EXIT_1
:MISSING_NANT
echo nant is missing.
goto :EXIT_1
:MISSINGSharpZipLib
echo SharpZipLib is missing.
goto :EXIT_1
:MISSINGIKVMDLL
echo You need to unpack ikvm.windward.8.5.0.3.nuget.
goto :EXIT_1
:MISSING_VS
echo Execute it in 'Developer Command Prompt for VS'.
goto :EXIT_1
:ERROREND
echo Something error happened.
goto :EXIT_1

:EXIT_1
popd
exit /B 1

:END
popd
