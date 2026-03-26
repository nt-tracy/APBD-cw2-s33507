namespace APBD_C02_s33507.Models;

public class Student(string fName, string lName) : User (fName, lName)
{
    public override string GetUserType() => "Student";
    public override int MaxRentals() => 2;
}