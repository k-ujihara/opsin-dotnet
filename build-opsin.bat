rem Before execute it, see the instruction in `README.md`.

call customize.bat

where /Q ikvmc
if errorlevel 1 goto :MISSING_IKVMC

pushd .

echo Building %OPSIN_JAR%.
ikvmc -target:library -keyfile:Opsin\Opsin.snk %OPSIN_JAR%
if errorlevel 1 goto :ERROREND
echo DLL of %OPSIN_JAR% is created in %HERE%.

where /Q msbuild
if errorlevel 1 goto :MISSING_VS
echo Building 
msbuild %HERE%\Opsin\Opsin.csproj /t:Build /p:Configuration=Release,Platform=AnyCPU
if errorlevel 1 goto :ERROREND

nuget pack "Opsin.nuspec" -Prop Configuration=Release -IncludeReferencedProjects
if errorlevel 1 goto :ERROREND

goto :END

:MISSING_IKVMC
echo IKVM compiler is missing. Build using "build-ikvmc.bat".
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
