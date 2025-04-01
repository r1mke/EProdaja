using EProdaja.Model;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdaja.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VrsteProizvodumController : BaseController<VrsteProizvodum, VrsteProizvodumSearchObject>
    {
        public VrsteProizvodumController(IVrsteProizvodumService service): base(service) { }
    }
}
