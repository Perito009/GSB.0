using System;
using System.Collections.Generic;

namespace GSB._0.Models
{
    public partial class DomaineDeSpecialite
    {
        public DomaineDeSpecialite()
        {
            Medecins = new HashSet<Medecin>();
        }

        public string IdSpecialite { get; set; } = null!;
        public string? IntituleDeSpecialite { get; set; }

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
