using QuintoProyecto.Models;

namespace QuintoProyecto.Services;

public class MedicamentoService {
  // Simula mi base de datos
  private readonly List<Medicamentos> _medicamentos = [
    new Medicamentos{
      Id = 1,
      Nombre = "Paracetamol",
      Descripción = "Analgésico y antipirético"
    },
    new Medicamentos{
      Id = 2,
      Nombre = "Ibuprofeno",
      Descripción = "Antiinflamatorio no esteroide"
    },
    new Medicamentos{
      Id = 3,
      Nombre = "Amoxicilina",
      Descripción = "Antibiótico de amplio espectro"
    }
  ];

  public List<Medicamentos> FindAll() {
    return _medicamentos;
  }

  public void Create(Medicamentos medicamento) {
    _medicamentos.Add(medicamento);
  }

  public bool Delete(int id)
  {
    var medicamento = _medicamentos.FirstOrDefault(m => m.Id == id);

    if (medicamento is null)
    {
      return false;
    }

    _medicamentos.Remove(medicamento);
    return true;
  }
}
    