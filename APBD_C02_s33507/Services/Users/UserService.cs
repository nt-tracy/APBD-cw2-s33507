using APBD_C02_s33507.Models;

namespace APBD_C02_s33507.Services.Users;

public class UserService : IUserService
{
    private readonly List<User> _users = [];

    public void AddUser(User user)
    {
        if (_users.Any(u => u.Id == user.Id))
        {
            throw new Exception($"Użytkownik o ID {user.Id} już istnieje.");
        }
        _users.Add(user);
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id) 
               ?? throw new Exception($"Nie znaleziono użytkownika o ID: {id}");
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public List<EquipmentRental> GetUserActiveRentals(User user, List<EquipmentRental> allRentals)
    {
        return allRentals.Where(r => r.User.Id == user.Id && !r.IsReturned).ToList();
    }
}