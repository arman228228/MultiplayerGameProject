How to setup project:

1. Clone
```bash
git clone https://github.com/arman228228/MultiplayerGameProject.git
cd MultiplayerGameProject
````

How to setup project database migration:
```bash
Setup settings in Presentation/appsettings.json
dotnet ef database update -p Infrastructure -s Presentation
````
How to build:
```bash
cd MultiplayerGameProject\Presentation
dotnet build MultiplayerGameProject.sln
dotnet run
````
