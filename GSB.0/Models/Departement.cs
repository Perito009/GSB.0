using System;
using System.Collections.Generic;

namespace GSB._0.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Medecins = new HashSet<Medecin>();
        }

        public string IdDepartement { get; set; } = null!;
        public string? NomDuDepartement { get; set; }
        public string? NomDeDistcict { get; set; }
        public int? CodeDeDistrict { get; set; }

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
