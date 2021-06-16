using System;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using LINQtoCSV;
using NSubstitute;
using Ubi.Application.DTOs;
using Ubi.Core.Entities;
using Ubi.Core.Interfaces;
using Ubi.Core.ValueObjects;
using Ubi.Infrastructure.Data;
using Xunit;
using Xunit.Abstractions;

namespace Ubi.Tests
{
    public class CameraRepositoryTest
    {
        private ITestOutputHelper _outputHelper;
        private readonly ICameraRepository _sut;

        public CameraRepositoryTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _sut = new CameraRepository(
                "testCSV1.csv",
                new CsvFileDescription
                {
                    SeparatorChar = ';',
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true
                }
            );
        }

        [Fact]
        public void GetAll_ShouldReturnAllCameras_WhenInputFileIsValid()
        {
            _sut.GetAll().Should().HaveCount(3).And.Subject.First().Should().BeEquivalentTo(new Camera
            {
                Number = 123,
                FullName = "UTR-CM-123 TestCamera1",
                Latitude = Latitude.From(52.093421),
                Longitude = Longitude.From(5.118278)
            });
            
        }
    }
}
