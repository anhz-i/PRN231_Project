using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIControllers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StudySetController : ControllerBase
    {
    }
}
