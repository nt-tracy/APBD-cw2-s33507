using APBD_C02_s33507.Models;

namespace APBD_C02_s33507.Exceptions;

public class MaxRentalLimitException(User user) : Exception($"Użytkownik {user.LName} przekroczył limit {user.MaxRentals} wypożyczeń.")
{

}