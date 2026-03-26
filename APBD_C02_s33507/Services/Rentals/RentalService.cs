using APBD_C02_s33507.Enums;
using APBD_C02_s33507.Exceptions;
using APBD_C02_s33507.Models;

namespace APBD_C02_s33507.Services;

public class RentalService : IRentalService
{
    private readonly List<EquipmentRental> _rentals = [];
    private const decimal DailyPenaltyRate = 15.0m;

    public void CreateRental(User user, Models.Equipment equipment, DateTime dueDate)
    {
        
        if (equipment.Status != AvailabilityStatus.available)
        {
            throw new UnavailableEquipmentException(equipment.Id);
        }


        int activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);
        if (activeRentalsCount >= user.MaxRentals())
        {
            throw new MaxRentalLimitException(user);
        }

        var rental = new EquipmentRental(user, equipment, DateTime.Now, dueDate);
        _rentals.Add(rental);
        
        equipment.Status = AvailabilityStatus.notAvailable;
    }

    public void CancelRental(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId) 
                     ?? throw new Exception("Nie znaleziono wypożyczenia.");

        if (rental.IsReturned) return;

        rental.DueDate = DateTime.Now;
        rental.IsReturned = true;
        rental.Equipment.Status = AvailabilityStatus.available;

        decimal penalty = CalculatePenalty(rental);
        if (penalty > 0)
        {
            Console.WriteLine($"Naliczono karę za opóźnienie: {penalty} zł.");
        }
    }

    private decimal CalculatePenalty(EquipmentRental rental)
    {
        if (!rental.ActualReturnDate.HasValue || rental.ActualReturnDate <= rental.DueDate)
            return 0;

        int delayDays = (rental.ActualReturnDate.Value.Date - rental.DueDate.Date).Days;
        return delayDays * DailyPenaltyRate;
    }

    public List<EquipmentRental> GetRentals(User user)
    {
        return _rentals.Where(r => r.User.Id == user.Id).ToList();
    }

    public List<EquipmentRental> GetAll()
    {
        return _rentals;
    }
}