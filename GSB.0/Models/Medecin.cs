using System;
using System.Collections.Generic;

namespace GSB._0.Models
{
    public partial class Medecin
    {
        public string IdMedecin { get; set; } = null!;
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? Adresse { get; set; }
        public int? Telephone { get; set; }
        public string IdSpecialite { get; set; } = null!;
        public string IdDepartement { get; set; } = null!;

        public virtual Departement IdDepartementNavigation { get; set; } = null!;
        public virtual DomaineDeSpecialite IdSpecialiteNavigation { get; set; } = null!;
    }
}
