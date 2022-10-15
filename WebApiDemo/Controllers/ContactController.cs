using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        [HttpGet("")]
        [Authorize(Roles ="Admin")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{ Id = 1, FirstName="Elvin",LastName="Camalzade"},
                new ContactModel{ Id = 2, FirstName="Tural",LastName="Eliyev"},
            };
        }
    }
}
