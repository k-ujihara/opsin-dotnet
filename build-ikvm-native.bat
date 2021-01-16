rem Before execute it, see the instruction in `README.md`.

call customize.bat

where /Q ikvmc
if %errorlevel% equ 0 goto :IKVM_OK
if not exist %IKVM_DIR%\bin\ikvmc.exe goto :MISSING_IKVMC
path %IKVM_DIR%\bin;%Path%
:IKVM_OK

pushd .

cd %HERE%\ikvm8\native
nant -D:cpu-arch=%VSCMD_ARG_TGT_ARCH%
if errorlevel 1 goto :ERROREND
echo ikvm-native-win32-%VSCMD_ARG_TGT_ARCH%.dll was built.

goto :END

:MISSING_IKVMC
echo IKVM compiler is missing. Build using "build-ikvmc.bat".
goto :EXIT_1
:ERROREND
echo Something error happened.
goto :EXIT_1

:EXIT_1
popd
exit /B 1

:END
popd
