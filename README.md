# OPSIN - Open Parser for Systematic IUPAC Nomenclature compiled for .NET using IKVM

This repo is to build [OPSIN - Open Parser for Systematic IUPAC Nomenclature](https://github.com/dan2097/opsin) for .NET Framework.

## Procedure to Build `opsin-2.5.0-jar-with-dependencies.dll`

- This is developed with Visual Studio 2019 on Windows 10.
- Install JDK8. Be sure to set PATH variable that javac can be executed.
- Download [NAnt 0.92](https://sourceforge.net/projects/nant/files/nant/0.92/nant-0.92-bin.zip) and unpack here.
- Clone [IKVM 8.5.0.3](https://github.com/windward-studios/ikvm8) and check out `8.5.0.3`.
- Download [ICSharpCode.SharpZipLib 1.3.1](https://www.nuget.org/api/v2/package/SharpZipLib/1.3.1) NuGet package, unpack here.
- Download [openjdk-8u45-b14](http://www.frijters.net/openjdk-8u45-b14-stripped.zip) and unpack here.
- Download [IKVM.WINWARD 8.5.0.3](https://www.nuget.org/api/v2/package/IKVM.WINDWARD/8.5.0.3) NuGet package and unpack here.
- Download [OPSIN 2.5.0](https://github.com/dan2097/opsin/releases/download/2.5.0/opsin-2.5.0-jar-with-dependencies.jar) and place here.
- Open `Developer Command Prompt for VS 2019`.
- Execute `build.bat`.

Notes

The format of nupkg is the same with ZIP. So you can unpack nupkg file using typical unzip tools like `7z`, or change the extension of the file to `.zip` and treat it as ZIP file.

This is used by Excel addin, [NCDK-Excel](https://github.com/kazuyaujihara/NCDK-Excel).
