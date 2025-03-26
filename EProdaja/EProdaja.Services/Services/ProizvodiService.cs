using EProdaja.Model;
using EProdaja.Services.Database;
using EProdaja.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProdaja.Services.Services
{
    public class ProizvodiService : IProizvodiService
    {

        public EProdajaContext Context { get; set; }

        public ProizvodiService(EProdajaContext context)
        {
            Context = context;
        }
        public List<Model.Proizvodi> GetList()
        {
            var list = Context.Proizvodis.ToList();
            var result = new List<Model.Proizvodi>();

            list.ForEach(item =>
            {
                result.Add(new Model.Proizvodi()
                {
                    ProizvodId = item.ProizvodId,
                    Cijena = item.Cijena,
                    Naziv = item.Naziv
                });
            });

            return result;
        }
    }
}
