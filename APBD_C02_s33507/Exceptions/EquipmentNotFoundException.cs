namespace APBD_C02_s33507.Exceptions;


public class EquipmentNotFoundException(int equipmentId) 
    : Exception($"Equipment with id {equipmentId} not found");