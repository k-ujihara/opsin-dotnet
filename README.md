# OPSIN - Open Parser for Systematic IUPAC Nomenclature - for .NET Framework

This repo is to build [OPSIN - Open Parser for Systematic IUPAC Nomenclature](https://github.com/dan2097/opsin) for .NET Framework using IKVM.

## How to Use

The basic usage is like this. You can refer OPSIN assembly via [nuget.org](nuget.org).

```CSharp
using Opsin;
using System;

class Program
{
    static void Main(string[] args)
    {
        var nts = NameToStructure.Instance;
        Console.WriteLine(nts.ParseToSmiles("acetonitrile"));
        Console.WriteLine(nts.ParseToCML("acetonitrile"));
        var result = nts.ParseChemicalName("acetonitrile");
        Console.WriteLine(result.GetExtendedSmiles());
    }
}
```

### Notice

NameToInchi feature does not work on x86.

## Procedure to Build

- This is developed with Visual Studio 2019 on Windows 10.

At first you need to build IKVM compiler. The procedure it here.

- Install JDK8. Be sure to set PATH variable that javac can be executed.
- Download [NAnt 0.92](https://sourceforge.net/projects/nant/files/nant/0.92/nant-0.92-bin.zip) and unpack here.
- Clone [IKVM 8.5.0.3](https://github.com/windward-studios/ikvm8) and check out `8.5.0.3`.
- Download [ICSharpCode.SharpZipLib 1.3.1](https://www.nuget.org/api/v2/package/SharpZipLib/1.3.1) NuGet package, unpack here.
- Download [openjdk-8u45-b14](http://www.frijters.net/openjdk-8u45-b14-stripped.zip) and unpack here.
- Download [IKVM.WINWARD 8.5.0.3](https://www.nuget.org/api/v2/package/IKVM.WINDWARD/8.5.0.3) NuGet package and unpack here.
- Download [OPSIN 2.5.0](https://github.com/dan2097/opsin/releases/download/2.5.0/opsin-2.5.0-jar-with-dependencies.jar) and place here.
- Open `Developer Command Prompt for VS 2019`.
- Execute `build-ikvmc.bat` to build IKVM compiler..
- Close prompt.

Next, you need to build `ikvm-native-win32-x86.dll` and `ikvm-native-win32-x64.dll`.

- Open `x64 Native Tools Command Prompt for VS 2019`.
- Execute `build-ikvm-native.bat`.
- Close prompt.
- Open `x86 Native Tools Command Prompt for VS 2019`.
- Execute `build-ikvm-native.bat`.
- Close prompt.

Finally, build NuGet package.

- Open `Developer Command Prompt for VS 2019`.
- Execute `build-opsin.bat` to build `OPSIN.#.#.#.#.nupkg`.
- Close prompt.

### Notes

The format of nupkg is the same with ZIP. So you can unpack nupkg file using typical unzip tools like `7z`, or change the extension of the file to `.zip` and treat it as ZIP file.
