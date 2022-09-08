using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/*https://dvoituron.com/2017/12/19/how-to-create-a-webapi-authenticated-by-jwt/*/
/*https://www.youtube.com/watch?v=3l4KHG2mppc*/
namespace MyJsonWebToken.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ValuesController : Controller
    {

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}