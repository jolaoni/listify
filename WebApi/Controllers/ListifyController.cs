using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("listify")]
    public class ListifyController : ControllerBase
    {
        private readonly ILogger<ListifyController> _logger;

        public ListifyController(ILogger<ListifyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get(int begin, int end, int index)
        {
            if (begin >= end)
                return 0;

            var list = new ListifyCollection(begin, end);

            return list[index];
        }
    }
}
