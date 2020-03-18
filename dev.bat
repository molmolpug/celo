set Api_Db_ConnectionString=User ID=user;Password=password;Host=localhost;Port=54321;Database=celo;Pooling=true;Command Timeout=0;

cd Celo.Api
dotnet build -c Production
dotnet watch run
#start "Celo.Api" dotnet watch run

:: no-op commit