using EProdaja.Model;
using EProdaja.Model.Requests;

namespace EProdaja.Services.Interfaces
{
    public interface IKorisniciService
    {
        List<Model.Korisnici> GetList();
        Korisnici Insert(KorisniciInsertRequest request);
        Korisnici Update(int id,KorisniciUpdateRequest request);

    }
}
