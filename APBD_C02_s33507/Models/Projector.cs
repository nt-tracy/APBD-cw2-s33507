namespace APBD_C02_s33507.Models;
using APBD_C02_s33507.Enums;

public class Projector(string name, string SerialNumber, string Producent, int BrightnessLumens, string InputPorts) 
    : Equipment(name, AvailabilityStatus.available, SerialNumber, Producent)
{
    public int Brightness { get; set; }
    public string InputPorts { get; set; }
}