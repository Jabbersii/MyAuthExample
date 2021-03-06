﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
