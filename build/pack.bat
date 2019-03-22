@echo off
echo %1
cd ..

rem clear old packages
del output\* /q/f/s

rem build
dotnet build Bing.NetCore.sln -c Release

rem pack
dotnet pack ./src/Bing.Utils/Bing.Utils.csproj
dotnet pack ./src/Bing/Bing.csproj
dotnet pack ./src/Bing.Security/Bing.Security.csproj
dotnet pack ./src/Bing.Logs/Bing.Logs.csproj
dotnet pack ./src/Bing.Logs.Exceptionless/Bing.Logs.Exceptionless.csproj
dotnet pack ./src/Bing.Logs.Log4Net/Bing.Logs.Log4Net.csproj
dotnet pack ./src/Bing.Logs.NLog/Bing.Logs.NLog.csproj
dotnet pack ./src/Bing.Logs.Serilog/Bing.Logs.Serilog.csproj
dotnet pack ./src/Bing.Events/Bing.Events.csproj
dotnet pack ./src/Bing.Datas.Dapper/Bing.Datas.Dapper.csproj
dotnet pack ./src/Bing.Datas.EntityFramework/Bing.Datas.EntityFramework.csproj
dotnet pack ./src/Bing.Datas.EntityFramework.MySql/Bing.Datas.EntityFramework.MySql.csproj
dotnet pack ./src/Bing.Datas.EntityFramework.PgSql/Bing.Datas.EntityFramework.PgSql.csproj
dotnet pack ./src/Bing.Datas.EntityFramework.SqlServer/Bing.Datas.EntityFramework.SqlServer.csproj
dotnet pack ./src/Bing.Applications/Bing.Applications.csproj
dotnet pack ./src/Bing.Webs/Bing.Webs.csproj
dotnet pack ./src/Bing.Extensions.AutoMapper/Bing.Extensions.AutoMapper.csproj
REM dotnet pack ./src/Bing.Extensions.Swashbuckle/Bing.Extensions.Swashbuckle.csproj
dotnet pack ./src/Bing.MailKit/Bing.MailKit.csproj
dotnet pack ./src/Bing.Biz/Bing.Biz.csproj
REM dotnet pack ./src/Bing.Geetest/Bing.Geetest.csproj
REM dotnet pack ./src/Bing.Sequence/Bing.Sequence.csproj
dotnet pack ./src/Bing.Caching.InMemory/Bing.Caching.InMemory.csproj
dotnet pack ./src/Bing.Caching.Redis/Bing.Caching.Redis.csproj
dotnet pack ./src/Bing.Caching.Memcached/Bing.Caching.Memcached.csproj
rem dotnet pack ./src/Bing.Caching.Hybrid/Bing.Caching.Hybrid.csproj
rem dotnet pack ./src/Bing.Offices/Bing.Offices.csproj
rem dotnet pack ./src/Bing.Offices.Npoi/Bing.Offices.Npoi.csproj

rem push
for %%i in (output\release\*.nupkg) do dotnet nuget push %%i -k %1 -s https://www.nuget.org/api/v2/package