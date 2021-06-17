using System;
using System.Collections.Generic;
using Ubi.Core.Entities;

namespace Ubi.Core.Interfaces
{
    public interface ICameraRepository
    {
        public IEnumerable<Camera> GetAll();
        public IEnumerable<Camera> Search(Func<Camera, bool> predicate);
    }
}
