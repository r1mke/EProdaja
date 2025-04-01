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
    public class VrsteProizvodumService:
        BaseService<Model.VrsteProizvodum, VrsteProizvodumSearchObject, Database.VrsteProizvodum>, IVrsteProizvodumService
    {

        public VrsteProizvodumService(EProdajaContext context, IMapper mapper) : base(context, mapper) { }

    }
}
