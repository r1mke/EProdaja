using System;
using System.Collections.Generic;
using System.Text;

namespace EProdaja.Model.Pagination
{
    public class Base
    {
        public int? Page { get; set; }  
        public int? PageSize { get; set; }
    }
}
