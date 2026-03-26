namespace APBD_C02_s33507.Services.Equipment;

public interface IEquipmentService
{
    public void AddEquipment(Models.Equipment equipment);
    public Models.Equipment GetEquipmentById(int id);
    public List<Models.Equipment> GetAll();
    public List<Models.Equipment> GetAvailable();
    public string GenerateInventoryReport();
}