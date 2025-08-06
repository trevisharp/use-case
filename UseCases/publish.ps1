$key = gc .\.key
$csproj = gc .\UseCases.csproj
$versionText = $csproj | % {
    if ($_.Contains("PackageVersion"))
    {
        $_
    }
}

$version = ""
$flag = 0
for ($i = 0; $i -lt $versionText.Length; $i++)
{
    $char = $versionText[$i]

    if ($flag -eq 1)
    {
        if ($char -eq "<")
        {
            break
        }

        $version += $char
    }

    if ($char -eq ">")
    {
        $flag = 1
    }
}

dotnet pack UseCases.sln -c Release
$file = ".\bin\Release\UseCases." + $version + ".nupkg"
cp $file UseCases.nupkg

dotnet nuget push UseCases.nupkg --api-key $key --source https://api.nuget.org/v3/index.json
rm .\UseCases.nupkg
cd..