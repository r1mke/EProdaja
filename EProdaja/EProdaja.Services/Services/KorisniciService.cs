using EProdaja.Model;
using EProdaja.Model.Pagination;
using EProdaja.Model.Requests;
using EProdaja.Model.SearchObjects;
using EProdaja.Services.Database;
using EProdaja.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EProdaja.Services.Services
{
    public class KorisniciService : BaseService<Model.Korisnici, KorisniciSearchObject, Database.Korisnici>, IKorisniciService
    {

        public KorisniciService(EProdajaContext context, IMapper mapper)
            : base(context, mapper) { }

        public override IQueryable<Database.Korisnici> AddFilter(KorisniciSearchObject search, IQueryable<Database.Korisnici> query)
        {
            var filteredQuery = query;

            if (!string.IsNullOrWhiteSpace(search?.ImeGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Ime.StartsWith(search.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Prezime.StartsWith(search.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                filteredQuery = filteredQuery.Where(x => x.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }

            if (search.IsKorisiciUlogeIncluded == true)
            {
                filteredQuery = filteredQuery.Include(x => x.KorisniciUloges).ThenInclude(s => s.Uloga);
            }

            return filteredQuery;
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            if(request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinke se ne poklapaju");
            }

            Database.Korisnici entity = new Database.Korisnici();
            Mapper.Map(request,entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            Context.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = Context.Korisnicis.Find(id);

            Mapper.Map(request, entity);

            if(request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinke se ne poklapaju");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }

            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(entity);
        }
    }
}
