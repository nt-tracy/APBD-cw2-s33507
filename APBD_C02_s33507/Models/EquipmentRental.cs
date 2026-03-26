namespace APBD_C02_s33507.Models;

public class EquipmentRental(Equipment equipment, User user, DateTime from, DateTime to, bool returned)
{
    private static int _nextId = 1;
    public int  Id { get; set; } =  ++_nextId;
    
    public Equipment Equipment { get; set; }
    public User User { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public bool ReturnedStatus { get; set; }
    
}