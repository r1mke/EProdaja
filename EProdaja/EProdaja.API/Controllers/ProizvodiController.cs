using EProdaja.Model;
using EProdaja.Model.Pagination;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : BaseController<Model.Proizvodi,ProizvodiSearchObject>
    {

        public ProizvodiController(IProizvodiService service): base(service) { }
        

    }
}
