using System;
using FluentAssertions;
using Ubi.Core.ValueObjects;
using Xunit;

namespace Ubi.Tests
{
    public class LatitudeTest
    {
        [Theory]
        [InlineData(-90)]
        [InlineData(90)]
        [InlineData(0)]
        [InlineData(1.23456)]
        public void Latitude_ShouldBeSuccessful_WhenGivenGoodValue(double value)
        {
            //Arrange + Act
            Func<Latitude> act = () => Latitude.From(value);
            
            //Assert
            act.Should().NotThrow();
            act.Invoke().Value.Should().Be(value);
        }
        
        [Theory]
        [InlineData(-90.001)]
        [InlineData(90.00001)]
        [InlineData(-int.MaxValue)]
        public void Latitude_ShouldThrow_WhenGivenBadValue(double value)
        {
            //Arrange + Act
            Func<Latitude> act = () => Latitude.From(value);
            
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("The Latitude is incorrectly set*");
        }
    }
}
