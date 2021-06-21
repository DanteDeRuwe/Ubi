using System;
using LINQtoCSV;
using Ubi.Infrastructure.Data;

namespace Ubi.Cli
{
    internal static class Program
    {
        internal static void Main(string name)
        {
            var repo = new CameraRepository(
                @"..\..\data\cameras-defb.csv",
                new CsvFileDescription
                {
                    SeparatorChar = ';',
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true
                });

            var cameras = repo.Search(c => c.FullName.Contains(name));

            Console.WriteLine(string.Join('\n', cameras));
        }
    }
}
