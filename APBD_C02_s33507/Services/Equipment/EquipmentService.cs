using APBD_C02_s33507.Enums;
using APBD_C02_s33507.Exceptions;
using APBD_C02_s33507.Models;
using System.Text;

namespace APBD_C02_s33507.Services.Equipment;

public class EquipmentService : IEquipmentService
{
    private readonly List<Models.Equipment> _equipmentList = [];

    public void AddEquipment(Models.Equipment equipment)
    {
        if (_equipmentList.Any(e => e.Id == equipment.Id))
        {
            throw new Exception($"Błąd: Sprzęt o ID {equipment.Id} już istnieje.");
        }
        _equipmentList.Add(equipment);
    }

    public Models.Equipment GetEquipmentById(int id)
    { 
        return _equipmentList.FirstOrDefault(e => e.Id == id) 
             ?? throw new UnavailableEquipmentException(id);
    }

    public List<Models.Equipment> GetAll()
    {
        return _equipmentList; // Zwraca pełną listę z aktualnymi statusami [cite: 34]
    }

    public List<Models.Equipment> GetAvailable()
    {
        return _equipmentList.Where(e => e.Status == AvailabilityStatus.available).ToList();
    }

    public string GenerateInventoryReport()
    {
        var total = _equipmentList.Count;
        var available = _equipmentList.Count(e => e.Status == AvailabilityStatus.available);
        var rented = total - available;

        var sb = new StringBuilder();
        sb.AppendLine("----- RAPORT INWENTARZOWY -----");
        sb.AppendLine($"Łączna liczba sprzętu: {total}");
        sb.AppendLine($"Dostępne do wypożyczenia: {available}");
        sb.AppendLine($"Aktualnie wypożyczone: {rented}");
        sb.AppendLine("-------------------------------");
        
        return sb.ToString();
    }
}