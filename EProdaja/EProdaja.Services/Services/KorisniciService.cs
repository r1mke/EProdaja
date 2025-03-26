﻿using EProdaja.Model;
using EProdaja.Model.Requests;
using EProdaja.Services.Database;
using EProdaja.Services.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EProdaja.Services.Services
{
    public class KorisniciService : IKorisniciService
    {

        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public KorisniciService(EProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public List<Model.Korisnici> GetList()
        {
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            var list = Context.Korisnicis.ToList();
            //list.ForEach(item =>
            //{
            //    result.Add(new Model.Korisnici()
            //    {
            //        KorisnikId = item.KorisnikId,
            //        Ime = item.Ime,
            //        Prezime = item.Prezime,
            //        Email = item.Email,
            //        Telefon = item.Telefon,
            //        KorisnickoIme = item.KorisnickoIme,
            //        Status = item.Status
            //    });
            //});


            result = Mapper.Map(list, result);
            return result;
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
