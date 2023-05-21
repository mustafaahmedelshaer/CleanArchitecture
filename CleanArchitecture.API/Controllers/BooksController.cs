using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //https://www.c-sharpcorner.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  List<string> Get()
        {
            return  new List<string>();
        }

    }
}
