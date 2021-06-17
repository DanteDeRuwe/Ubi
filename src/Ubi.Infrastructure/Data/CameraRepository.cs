using System;
using System.Collections.Generic;
using System.Linq;
using LINQtoCSV;
using Ubi.Application.DTOs;
using Ubi.Application.Mappers;
using Ubi.Core.Entities;
using Ubi.Core.Interfaces;

namespace Ubi.Infrastructure.Data
{
    public class CameraRepository : ICameraRepository
    {
        private readonly CsvFileDescription _description;
        private readonly CsvContext _context = new();
        private readonly string _filename;

        public CameraRepository(string filename, CsvFileDescription description)
        {
            _filename = filename;
            _description = description;
        }

        public IEnumerable<Camera> GetAll()
        {
            return _context.Read<CameraDTO>(_filename, _description).Select(c => c.MapToCamera());
        }

        public IEnumerable<Camera> Search(Func<Camera, bool> predicate)
        {
            return GetAll().Where(predicate);
        }
    }
}
