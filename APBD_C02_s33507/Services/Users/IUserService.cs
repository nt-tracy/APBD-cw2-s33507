using APBD_C02_s33507.Models;

namespace APBD_C02_s33507.Services.Users;

public interface IUserService
{
    void AddUser(User user);           
    User GetUserById(int id);          
    List<User> GetAllUsers();          
    List<EquipmentRental> GetUserActiveRentals(User user, List<EquipmentRental> allRentals);
}