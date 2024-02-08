using ApiRdv.Models;
using System.Collections.Generic;
namespace ApiPraticien.Models
{
    public class Praticien
    {
        public int Id { get; set; }
        public string NomPraticien { get; set; }
        public string Specialite { get; set; }

        // Ajout d'une propriété de navigation pour les rendez-vous associés (facultatif)
       // public ICollection<Rdv> Rdvs { get; set; }
    }
}
