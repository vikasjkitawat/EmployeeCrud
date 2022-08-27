## API

### Entity Framework Core
```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 3.1.28
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.28
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.28
```

### Swagger
```powershell
Install-Package Swashbuckle.AspNetCore -Version 6.4.0
```

#### Startup file changes for Swagger

ConfigureServices Method Changes
```csharp
services.AddSwaggerGen();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Implement Swagger UI",
        Description = "A simple example to Implement Swagger UI",
        Contact = new OpenApiContact
        {
            Name = "Vikas K",
            Email = "vikas@demo.com",
        },
    });
});
```


Configure Method Changes
```csharp
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
});
```

Update startup to be changed to swagger endpoint

## UI