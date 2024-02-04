using System.Collections.Generic;
using ApiPraticien.Data;
using ApiPraticien.Models;

public class PraticienRepository
{
    private readonly PraticienDbContext _context;

    public PraticienRepository(PraticienDbContext context)
    {
        _context = context;
    }

    public Praticien GetPraticienById(int id)
    {
        return _context.Praticiens.Find(id);
    }

    public Praticien CreatePraticien(Praticien praticien)
    {
        _context.Praticiens.Add(praticien);
        _context.SaveChanges();
        return praticien;
    }

    public Praticien UpdatePraticien(int id, Praticien praticien)
    {
        var existingPraticien = _context.Praticiens.Find(id);
        if (existingPraticien == null)
        {
            return null;
        }

        existingPraticien.NomPraticien = praticien.NomPraticien;
        existingPraticien.Specialite = praticien.Specialite;

        _context.SaveChanges();
        return existingPraticien;
    }

    public bool DeletePraticien(int id)
    {
        var praticien = _context.Praticiens.Find(id);
        if (praticien == null)
        {
            return false;
        }

        _context.Praticiens.Remove(praticien);
        _context.SaveChanges();
        return true;
    }
}
