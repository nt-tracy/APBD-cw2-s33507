namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Camera(string name, AvailabilityStatus status, string SerialNumber, string Producent, double SensorResolution, string VideoResolution) 
    : EquipmentType(name, status, SerialNumber, Producent)
{
    
}