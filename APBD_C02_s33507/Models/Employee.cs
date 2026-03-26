namespace APBD_C02_s33507.Models;

public class Employee(string fName, string lName) : User(fName, lName)
{
    public override string GetUserType() => "Employee";
    public override int MaxRentals() => 5;
}