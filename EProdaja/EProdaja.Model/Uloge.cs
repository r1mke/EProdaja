using System.Collections.Generic;

namespace EProdaja.Model
{
    public class Uloge
    {
        public int UlogaId { get; set; }

        public string Naziv { get; set; } = null!;

        public string? Opis { get; set; }

    }
}