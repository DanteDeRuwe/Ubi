using LINQtoCSV;
using Microsoft.Extensions.DependencyInjection;
using Ubi.Core.Interfaces;
using Ubi.Infrastructure.Data;

namespace Ubi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICameraRepository>(sp => new CameraRepository(
                @"..\..\data\cameras-defb.csv",
                new CsvFileDescription
                {
                    SeparatorChar = ';',
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true
                }));
        }
    }
}
