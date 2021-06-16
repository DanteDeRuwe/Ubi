using Ubi.Core.ValueObjects;

namespace Ubi.Core.Entities
{
    public record Camera
    {
        public int? Number { get; init; }
        public string FullName { get; init; }
        public Latitude Latitude { get; init; }
        public Longitude Longitude { get; init; }
    }
}
