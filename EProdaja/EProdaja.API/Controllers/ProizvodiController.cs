using EProdaja.Model;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {

        protected IProizvodiService _service;
        public ProizvodiController(IProizvodiService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Proizvodi> GetList()
        {
            return _service.GetList();
        }
    }
}
