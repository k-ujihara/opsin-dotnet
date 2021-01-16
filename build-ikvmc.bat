rem Before execute it, see the instruction in `README.md`.

call customize.bat

pushd .

echo Preparing to build IKVM.
where /Q ikvmc
if %errorlevel% equ 0 goto :END_IKVM_BUILD
if not exist %IKVM_DIR%\bin mkdir %IKVM_DIR%\bin
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
cd %IKVM_DIR%\ikvm
nant
if errorlevel 1 goto :ERROREND
cd %IKVM_DIR%\ikvmstub
nant
if errorlevel 1 goto :ERROREND
cd %IKVM_DIR%\ikvmc
nant
if errorlevel 1 goto :ERROREND
:ADD_IKVM_TO_PATH
path %IKVM_DIR%\bin;%Path%
:END_IKVM_BUILD

goto :END

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
