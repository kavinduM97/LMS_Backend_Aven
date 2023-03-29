using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Aven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly LmsContext _context1;
        public EmployeeController(LmsContext context)   
        {


            _context1 = context;

        }
    }
}
