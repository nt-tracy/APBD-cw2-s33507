namespace APBD_C02_s33507.Models;

public class EquipmentRental
{
    private static int _nextId = 0;
    public int Id { get; } = ++_nextId;

    public Equipment Equipment { get; set; }
    public User User { get; set; }
    
    public DateTime RentDate { get; set; }     // Kiedy wypożyczono 
    public DateTime DueDate { get; set; }      // Termin zwrotu 
    public DateTime? ActualReturnDate { get; set; } // Faktyczny zwrot 
    public bool IsReturned { get; set; }       // Czy zwrócono 

    // Konstruktor dopasowany do logiki CreateRental
    public EquipmentRental(User user, Equipment equipment, DateTime rentDate, DateTime dueDate)
    {
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        DueDate = dueDate;
        IsReturned = false;
    }
}