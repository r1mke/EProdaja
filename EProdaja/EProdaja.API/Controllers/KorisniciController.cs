using EProdaja.Model;
using EProdaja.Model.Pagination;
using EProdaja.Model.Requests;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : BaseController<Model.Korisnici, KorisniciSearchObject>
    {

        public KorisniciController(IKorisniciService service) : base(service) { }
    }
}
