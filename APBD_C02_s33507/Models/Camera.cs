namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Camera(string name, string SerialNumber, string Producent, double SensorResolution, string VideoResolution) 
    : Equipment(name, AvailabilityStatus.available, SerialNumber, Producent)
{
    public double SensorResolution { get; set; }
    public string VideoResolution { get; set; }
    
}