using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using ApiRdv.Models;
using ApiRdv.Data;
using Microsoft.EntityFrameworkCore;

public class RdvService
{
    private readonly RdvRepository _rdvRepository;

    public RdvService(RdvRepository rdvRepository)
    {
        _rdvRepository = rdvRepository;
    }
    public IEnumerable<Rdv> GetAllRdv()
    {
        return _rdvRepository.GetAllRdv();
    }

    public Rdv GetRdvById(int id)
    {
        return _rdvRepository.GetRdvById(id);
    }
    //public List<Rdv> GetRdvByPraticien(int idPraticien)
    //{
    //    // Logique pour récupérer les rendez-vous en fonction de l'identifiant du praticien
    //    return _rdvRepository.Rdvs.Where(r => r.IdPraticien == idPraticien).ToList();
    //}

    public Rdv CreateRdv(Rdv rdv)
    {
        return _rdvRepository.CreateRdv(rdv);
    }

    public Rdv UpdateRdv(int id, Rdv rdv)
    {
        return _rdvRepository.UpdateRdv(id, rdv);
    }

    public bool DeleteRdv(int id)
    {
        return _rdvRepository.DeleteRdv(id);
    }
}
