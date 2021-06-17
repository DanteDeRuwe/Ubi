using System.Linq;
using System.Text.RegularExpressions;
using Ubi.Application.DTOs;
using Ubi.Core.Entities;
using Ubi.Core.ValueObjects;

namespace Ubi.Application.Mappers
{
    public static class CameraMapper
    {
        public static Camera MapToCamera(this CameraDTO dto)
        {
            return new()
            {
                FullName = dto.Camera,
                Number = ExtractNumber(dto.Camera),
                Latitude = Latitude.From(dto.Latitude),
                Longitude = Longitude.From(dto.Longitude),
            };
        }
        
        private static int? ExtractNumber(string fullName)
        {
            if (fullName is null) return null;
            var num = Regex.Match(fullName,@"^UTR-CM-(\d+)?.*").Groups[1].Value;
            var isValid = int.TryParse(num, out var result);
            return isValid ? result : null;
        }
    }
}
