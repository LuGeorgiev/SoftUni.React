using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitChallenge.Server.Features
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
