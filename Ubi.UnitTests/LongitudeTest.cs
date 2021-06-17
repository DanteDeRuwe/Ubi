using System;
using FluentAssertions;
using Ubi.Core.ValueObjects;
using Xunit;

namespace Ubi.Tests
{
    public class LongitudeTest
    {
        [Theory]
        [InlineData(-90)]
        [InlineData(90)]
        [InlineData(180)]
        [InlineData(-180)]
        [InlineData(0)]
        [InlineData(1.23456)]
        public void Longitude_ShouldBeSuccessful_WhenGivenGoodValue(double value)
        {
            //Arrange + Act
            Func<Longitude> act = () => Longitude.From(value);
            
            //Assert
            act.Should().NotThrow();
            act.Invoke().Value.Should().Be(value);
        }
        
        [Theory]
        [InlineData(-180.001)]
        [InlineData(180.00001)]
        [InlineData(-int.MaxValue)]
        public void Longitude_ShouldThrow_WhenGivenBadValue(double value)
        {
            //Arrange + Act
            Func<Longitude> act = () => Longitude.From(value);
            
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("The Longitude is incorrectly set*");
        }
    }
}
