using APBD_C02_s33507.Enums;

namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public abstract class EquipmentType(string name, AvailabilityStatus status, string SerialNumber, string Producent )
{
    public static int _nextId = 1;
    
    public int Id { get; set; } =  ++_nextId;
    
    public string Name { get; set; }
    public AvailabilityStatus Status { get; set; }
    public string SerialNumber { get; set; }
    public string Producent { get; set; }
    
}