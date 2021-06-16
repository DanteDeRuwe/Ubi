using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Ubi.Api;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>())
    .Build()
    .Run();
