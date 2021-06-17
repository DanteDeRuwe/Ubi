using System.Linq;
using FluentAssertions;
using LINQtoCSV;
using Ubi.Core.Entities;
using Ubi.Core.ValueObjects;
using Ubi.Infrastructure.Data;
using Xunit;
using Xunit.Abstractions;

namespace Ubi.Tests
{
    public class CameraRepositoryTest
    {
        private readonly CsvFileDescription _description = new()
        {
            SeparatorChar = ';',
            FirstLineHasColumnNames = true
        };

        [Fact]
        public void GetAll_ShouldReturnAllCameras_WhenInputFileIsValid()
        {
            //Arrange
            var sut = new CameraRepository(
                "testCSV1.csv",
                _description
            );

            //Act
            var result = sut.GetAll();

            //Assert
            result.Should().HaveCount(3).And.Subject.First().Should().BeEquivalentTo(new Camera
            {
                Number = 123,
                FullName = "UTR-CM-123 TestCamera1",
                Latitude = Latitude.From(52.093421),
                Longitude = Longitude.From(5.118278)
            });
        }
    }
}
