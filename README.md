# Projects

* `Core` - `C++` dynamic library
* `CsharpClient` - `C#` console application

## Steps performed

### 1. Build dependency

Add `Core` project as a Project Reference to `CsharpClient` project. Now `Core` build is triggered every time `CsharpClient` is built.

### 2. Build output path

Make the `.dll` file from `Core` end up in the same build output with `CsharpClient`'s. I decided to put the build output from both projects in `bin` directory in solution root folder.

For `C++` project, I set _Output Directory_ to `$(SolutionDir)\bin\$(Platform)\$(Configuration)\` for **all** build configurations.

For `C#` project, I set `OutputPath` to `$(SolutionDir)\bin\$(Platform)\$(Configuration)\` for **all** build configurations.

For `C#` project, I set `AppendTargetFrameworkToOutputPath` to `false` to prevent creation of additional nested directories in the build output.

Here is the content of the `.csproj` file for `C#` project:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <Platforms>x64;x86</Platforms>
  </PropertyGroup>

  <PropertyGroup>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|x86'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|x86'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|x86'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|x86'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|x64'">
    <OutputPath>$(SolutionDir)\bin\$(Platform)\$(Configuration)\</OutputPath>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\Core\Core.vcxproj" />
  </ItemGroup>

</Project>

```

### 3. Explicit target architecture

Explicitly build for `x86` or `x64`. The `Any CPU` configuration can lead to a mismatch between the platforms.


## Steps that need to be done

* Publish script
