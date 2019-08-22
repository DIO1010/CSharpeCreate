if "%1" == "-r" (
    dotnet build -c Release -o ./
) else (
    dotnet build -o ./
)