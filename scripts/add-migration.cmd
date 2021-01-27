@echo off

set /p name="Enter migration name: "
dotnet ef migrations add %name%  --startup-project ..\src\GeolettApi.Web --project ..\src\GeolettApi.Infrastructure
