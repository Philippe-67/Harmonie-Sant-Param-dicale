using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using ApiRdv.Models;
using ApiRdv.Data;
using Microsoft.EntityFrameworkCore;
public class RdvRepository
{
    private readonly RdvDbContext _rdvRepository;

    public IEnumerable<object> Rdvs { get; internal set; }

    public RdvRepository(RdvDbContext rdvRepository)
    {
        _rdvRepository = rdvRepository;
    }
    public IEnumerable<Rdv> GetAllRdv()
    {
        // Implémentez la logique pour récupérer tous les rendez-vous de la source de données
        return _rdvRepository.Rdvs.ToList(); // Exemple avec Entity Framework
    }

    public Rdv GetRdvById(int id)
    {
        return _rdvRepository.Rdvs.Find(id);
    }

    public Rdv CreateRdv(Rdv rdv)
    {
        _rdvRepository.Rdvs.Add(rdv);
        _rdvRepository.SaveChanges();
        return rdv;
    }

    public Rdv UpdateRdv(int id, Rdv rdv)
    {
        var existingRdv = _rdvRepository.Rdvs.Find(id);
        if (existingRdv == null)
        {
            return null;
        }

        existingRdv.Date = rdv.Date;
        existingRdv.NomPatient = rdv.NomPatient;
        existingRdv.NomPraticien = rdv.NomPraticien;

        _rdvRepository.SaveChanges();
        return existingRdv;
    }

    public bool DeleteRdv(int id)
    {
        var rdv = _rdvRepository.Rdvs.Find(id);
        if (rdv == null)
        {
            return false;
        }

        _rdvRepository.Rdvs.Remove(rdv);
        _rdvRepository.SaveChanges();
        return true;
    }
}
