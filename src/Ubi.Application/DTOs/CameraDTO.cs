namespace Ubi.Application.DTOs
{
    public record CameraDTO
    {
        public string Camera { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
