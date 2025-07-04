@echo off

echo ----------------------------------------
echo   [Checking] .NET SDK...
echo ----------------------------------------

where dotnet >nul 2>nul
IF %ERRORLEVEL% NEQ 0 (
    echo.
    echo   [ERROR] .NET SDK not found.
    echo   Please install .NET 9.0 or higher:
    echo   https://dotnet.microsoft.com/download/dotnet/9.0
    pause
    exit /b
)

for /f %%i in ('dotnet --version') do set VER=%%i
echo %VER% | findstr "^9\." >nul
IF %ERRORLEVEL% NEQ 0 (
    echo.
    echo   [WARNING] .NET SDK version %VER% found, but .NET 9.0 is required.
    echo   https://dotnet.microsoft.com/download/dotnet/9.0
    pause
    exit /b
)

echo   [OK] .NET %VER% detected. All good. :)

echo ----------------------------------------
echo   [Restoring] Packages...
echo ----------------------------------------
dotnet restore

echo ----------------------------------------
echo 	[INFO] If no errors occur below while running the API,
echo         it should be available at: http://localhost:5083
echo ----------------------------------------

echo   [Running] API... :)
echo ----------------------------------------
dotnet run

pause
