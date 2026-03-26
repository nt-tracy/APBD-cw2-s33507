namespace APBD_C02_s33507.Services;
using APBD_C02_s33507.Models;

public interface IRentalService
{
    public void CreateRental(User user, Models.Equipment equipment, DateTime dueDate);
    public decimal ReturnEquipment(int reservationId);
    public List<EquipmentRental> GetRentals(User user);
    public List<EquipmentRental> GetAll();
}