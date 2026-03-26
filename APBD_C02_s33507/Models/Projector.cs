namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Projector(string name, AvailabilityStatus status, string SerialNumber, string Producent, int BrightnessLumens, List<string> InputPorts) 
    : EquipmentType(name, status, SerialNumber, Producent)
{
    
}