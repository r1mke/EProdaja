using EProdaja.Model;
using EProdaja.Model.Requests;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {

        protected IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Korisnici> GetList()
        {
            return _service.GetList();
        }

        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            return _service.Update(id,request);
        }


    }
}
