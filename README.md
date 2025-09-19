How to setup project:

1. Clone repository:
```bash
git clone https://github.com/arman228228/MultiplayerGameProject.git
cd MultiplayerGameProject
````
2. Setup project database migration:
```bash
Setup settings in Presentation/appsettings.json
dotnet ef database update -p Infrastructure -s Presentation
````
3. Build:
```bash
cd MultiplayerGameProject\Presentation
dotnet build MultiplayerGameProject.sln
dotnet run
````
