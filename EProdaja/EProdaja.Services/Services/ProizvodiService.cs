using EProdaja.Model;
using EProdaja.Model.Pagination;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Database;
using EProdaja.Services.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProdaja.Services.Services
{
    public class ProizvodiService :BaseService<Model.Proizvodi,ProizvodiSearchObject, Database.Proizvodi> , IProizvodiService
    {
         
        public ProizvodiService(EProdajaContext context, IMapper mapper)
            : base(context, mapper) { }

        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = query;

            if(!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x=>x.Naziv.Contains(search.FTS));
            }

            return filteredQuery;
        }
    }
}
