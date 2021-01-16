set HERE=%~dp0.
call customize.bat

rmdir /Q /S %IKVM_DIR%\bin
del opsin-2.5.0-jar-with-dependencies.dll
rmdir /Q /S %HERE%\Opsin\bin
rmdir /Q /S %HERE%\Opsin\obj
