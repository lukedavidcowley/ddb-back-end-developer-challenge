using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductName.Business.Models;

namespace ProductName.GameEngine.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        [Route("{characterId}/hp/add")]
        public bool AddHitPoints(Guid characterId, int value)
        {
            throw new NotImplementedException();
        }

        [Route("{characterId}/hp/add/temporary")]
        public bool AddTemporaryHitPoints(Guid characterId, int value)
        {
            throw new NotImplementedException();
        }

        [Route("{characterId}/attack")]
        public bool Attack(Guid characterId, int value, DamageType damageType)
        {
            throw new NotImplementedException();
        }
    }
}