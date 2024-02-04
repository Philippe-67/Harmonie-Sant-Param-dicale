using ApiPraticien.Models;

public class PraticienService
{
    private readonly PraticienRepository _praticienRepository;

    public PraticienService(PraticienRepository praticienRepository)
    {
        _praticienRepository = praticienRepository;
    }
    public IEnumerable<Praticien> GetAllPraticien()
    {
        return _praticienRepository.GetAllPraticien();
    }

    public Praticien GetPraticienById(int id)
    {
        return _praticienRepository.GetPraticienById(id);
    }

    public Praticien CreatePraticien(Praticien praticien)
    {
        return _praticienRepository.CreatePraticien(praticien);
    }

    public Praticien UpdatePraticien(int id, Praticien praticien)
    {
        return _praticienRepository.UpdatePraticien(id, praticien);
    }

    public bool DeletePraticien(int id)
    {
        return _praticienRepository.DeletePraticien(id);
    }
}
