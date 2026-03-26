namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Laptop(string name, string SerialNumber, string Producent, int RAMCapacity, string ProcessorModel) 
    : Equipment(name, AvailabilityStatus.available, SerialNumber, Producent)
{
    public int RamCapacity { get; set; }
    public string ProcessorModel { get; set; }
}