#  Project API - Code first

# Cài dotnet ef để tạo code first
```bash
dotnet tool install --global dotnet-ef
```

## Khởi động và chạy dự án
```bash
dotnet ef migrations add Update1 -v --context AppDataContext
dotnet ef database update -v --context AppDataContext
dotnet run seeddata
```

