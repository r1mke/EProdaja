﻿using System;
using System.Collections.Generic;

namespace EProdaja.Services.Database;

public partial class IzlazStavke
{
    public int IzlazStavkaId { get; set; }

    public int IzlazId { get; set; }

    public int ProizvodId { get; set; }

    public int Kolicina { get; set; }

    public decimal Cijena { get; set; }

    public decimal? Popust { get; set; }

    public virtual Izlazi Izlaz { get; set; } = null!;

    public virtual Proizvodi Proizvod { get; set; } = null!;
}
