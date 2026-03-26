namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Laptop(string name, AvailabilityStatus status, string SerialNumber, string Producent, int RAMCapacity, string ProcessorModel) 
    : EquipmentType(name, status, SerialNumber, Producent)
{
    
}