using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ubi.Core.Entities;
using Ubi.Core.Interfaces;

namespace Ubi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CamerasController : ControllerBase
    {
        private readonly ICameraRepository _cameraRepository;

        public CamerasController(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }
        
        [HttpGet("")]
        public IEnumerable<Camera> GetAll()
        {
            return _cameraRepository.GetAll();
        }
    }
}
