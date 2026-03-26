using APBD_C02_s33507.Models;
using APBD_C02_s33507.Services;
using APBD_C02_s33507.Services.Equipment;
using APBD_C02_s33507.Services.Users;

IEquipmentService equipmentService = new EquipmentService();
IUserService userService = new UserService();
IRentalService rentalService = new RentalService();

Console.WriteLine("=== SYSTEM WYPOŻYCZALNI SPRZĘTU APBD ===\n");

var laptop = new Laptop("Dell XPS 15", "SN-123", "Dell", 32, "Intel i9");
var camera = new Camera("Sony A7 IV", "SN-999", "Sony", 33, "4K");
var projector = new Projector("Epson EH", "SN-555", "Epson", 3000, "HDMI");

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(projector);

var student = new Student("Jan", "Kowalski");
var employee = new Employee("Anna", "Nowak"); 

userService.AddUser(student);
userService.AddUser(employee);

Console.WriteLine($"[Operacja]: Wypożyczanie {laptop.Name} dla studenta...");
rentalService.CreateRental(student, laptop, DateTime.Now.AddDays(7));
Console.WriteLine($"Status sprzętu po wypożyczeniu: {laptop.Status}\n");

try 
{
    Console.WriteLine("[Próba]: Wypożyczenie już zajętego laptopa...");
    rentalService.CreateRental(employee, laptop, DateTime.Now.AddDays(5));
} 
catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }


try 
{
    Console.WriteLine("\n[Próba]: Przekroczenie limitu wypożyczeń studenta...");
    rentalService.CreateRental(student, camera, DateTime.Now.AddDays(1)); 
    rentalService.CreateRental(student, projector, DateTime.Now.AddDays(1));
} 
catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}\n"); }

Console.WriteLine("[Operacja]: Zwrot aparatu przez studenta (w terminie)...");
decimal penalty1 = rentalService.ReturnEquipment(camera.Id);
Console.WriteLine($"Zwrot zakończony. Naliczona kara: {penalty1} zł\n");


Console.WriteLine("[Operacja]: Symulacja zwrotu laptopa po terminie...");
var rentalToUpdate = rentalService.GetAll().First(r => r.Equipment.Id == laptop.Id);
rentalToUpdate.DueDate = DateTime.Now.AddDays(-5); 

decimal penalty2 = rentalService.ReturnEquipment(laptop.Id);
Console.WriteLine($"Zwrot spóźniony o 5 dni. Naliczona kara: {penalty2} zł\n");

Console.WriteLine(equipmentService.GenerateInventoryReport());
