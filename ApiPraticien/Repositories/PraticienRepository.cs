using System.Collections.Generic;
using ApiPraticien.Data;
using ApiPraticien.Models;

public class PraticienRepository
{
    private readonly PraticienDbContext _praticienRepository;

    public PraticienRepository(PraticienDbContext praticienRepository)
    {
        _praticienRepository = praticienRepository;
    }
    public IEnumerable<Praticien> GetAllPraticien()
    {
        // Implémentez la logique pour récupérer tous les rendez-vous de la source de données
        return _praticienRepository.Praticiens.ToList(); // Exemple avec Entity Framework
    }

    public Praticien GetPraticienById(int id)
    {
        return _praticienRepository.Praticiens.Find(id);
    }

    public Praticien CreatePraticien(Praticien praticien)
    {
        _praticienRepository.Praticiens.Add(praticien);
        _praticienRepository.SaveChanges();
        return praticien;
    }

    public Praticien UpdatePraticien(int id, Praticien praticien)
    {
        var existingPraticien = _praticienRepository.Praticiens.Find(id);
        if (existingPraticien == null)
        {
            return null;
        }

        existingPraticien.NomPraticien = praticien.NomPraticien;
        existingPraticien.Specialite = praticien.Specialite;

        _praticienRepository.SaveChanges();
        return existingPraticien;
    }

    public bool DeletePraticien(int id)
    {
        var praticien = _praticienRepository.Praticiens.Find(id);
        if (praticien == null)
        {
            return false;
        }

        _praticienRepository.Praticiens.Remove(praticien);
        _praticienRepository.SaveChanges();
        return true;
    }
}
