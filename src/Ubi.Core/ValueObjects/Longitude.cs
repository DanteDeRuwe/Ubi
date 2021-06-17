using System;
using ValueOf;

namespace Ubi.Core.ValueObjects
{
    // using a value object to treat so-called primitive obsession
    public class Longitude : ValueOf<double, Longitude>
    {
        private const double MinimumLongitude = -180;
        private const double MaximumLongitude = 180;

        protected override void Validate()
        {
            if (Value is< MinimumLongitude or> MaximumLongitude)
            {
                throw new ArgumentException(
                    $"The {nameof(Longitude)} is incorrectly set. It's value should be between {MinimumLongitude} and {MaximumLongitude}.");
            }
        }
    }
}
