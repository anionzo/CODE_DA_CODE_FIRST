#  Project API - Code first

## Khởi động và chạy dự án
```bash
dotnet ef migrations add Update1 -v --context AppDataContext
dotnet ef database update -v --context AppDataContext
dotnet run seeddata
```

