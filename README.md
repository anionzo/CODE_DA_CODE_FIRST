# Hướng Dẫn Tạo Project API

## Bước 1: Tạo Project trên GitHub
Tạo một repository mới trên GitHub để lưu trữ mã nguồn của dự án.

## Bước 2: Tạo Project API
Tạo một dự án ASP.NET Core API. Bạn có thể sử dụng Visual Studio hoặc dòng lệnh để tạo dự án mới.

## Bước 3: .gitignore
Thêm file `.gitignore` cho Visual Studio. Bạn có thể sử dụng nội dung từ [VisualStudio.gitignore](https://github.com/github/gitignore/blob/main/VisualStudio.gitignore).

## Bước 4: Cài Đặt Thư Viện JwtBearer
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0 
```
## Bước 5: Cài Đặt Thư Viện Entity Framework Core Tools
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.25
```
## Bước 6: Cài Đặt Thư Viện Entity Framework Core SqlServer Provider
```bash 
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.25
```

## Bước 7: Cài Đặt Thư Viện Entity Framework Core Design
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.25
```

## Bước 8: Cài Đặt Thư Viện Newtonsoft.Json
```bash
dotnet add package Newtonsoft.Json --version 13.0.3
```

## Bước 9: Cài Đặt Thư Viện TimeZoneConverter
```bash
dotnet add package TimeZoneConverter
```

