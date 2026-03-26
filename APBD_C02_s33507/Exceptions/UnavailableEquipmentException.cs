namespace APBD_C02_s33507.Exceptions;

public class UnavailableEquipmentException(int equipmentId) : Exception($"Equipment with id {equipmentId} is not available.")
{
    
}