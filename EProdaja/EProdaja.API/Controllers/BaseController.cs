using EProdaja.Model.Pagination;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TModel, TSearch> : ControllerBase
         where TSearch : BaseSearchObject
    {
        protected IService<TModel, TSearch> _service;
        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]

        public PagedResult<TModel> GetList([FromQuery] TSearch searchObject) 
        {
            return _service.GetPaged(searchObject);
        }

        [HttpGet("{id}")]
        public TModel GetList(int id)
        {
            return _service.GetById(id);
        }

    }
}
