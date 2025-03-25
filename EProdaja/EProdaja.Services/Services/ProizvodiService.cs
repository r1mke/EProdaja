using EProdaja.Model;
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
        public List<Proizvodi> lista = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodId = 1,
                Naziv = "Laptop",
                Cijena = 1500
            },
            new Proizvodi()
            {
                ProizvodId = 2,
                Naziv = "Mobitel",
                Cijena = 1000
            },
            new Proizvodi()
            {
                ProizvodId = 3,
                Naziv = "Monitor",
                Cijena = 500
            }

        };


        public List<Proizvodi> GetList()
        {
            return lista;
        }
    }
}
