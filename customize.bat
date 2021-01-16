set HERE=%~dp0.
set NANT_DIR=%HERE%\nant-0.92
set IKVM_DIR=%HERE%\ikvm8
set SharpZipLib_DIR=%HERE%\sharpziplib.1.3.1
set IKVMWINWARD_DIR=%HERE%\ikvm.windward.8.5.0.3
set OPSIN_JAR=opsin-2.5.0-jar-with-dependencies.jar

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

goto :END

:MISSING_JAVAC
echo javac is missing.
goto :EXIT_1
:MISSING_NANT
echo nant is missing.
goto :EXIT_1

:EXIT_1
exit /B 1

:END
