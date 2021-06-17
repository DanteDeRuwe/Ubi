using System;
using ValueOf;

namespace Ubi.Core.ValueObjects
{
    // using a value object to treat so-called primitive obsession
    public class Latitude : ValueOf<double, Latitude>
    {
        private const double MinimumLatitude = -90;
        private const double MaximumLatitude = 90;

        protected override void Validate()
        {
            if (Value is< MinimumLatitude or> MaximumLatitude)
            {
                throw new ArgumentException(
                    $"The {nameof(Latitude)} is incorrectly set. It's value should be between {MinimumLatitude} and {MaximumLatitude}.");
            }
        }
    }
}
