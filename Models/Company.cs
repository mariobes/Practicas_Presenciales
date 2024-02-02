namespace Practices.Models;
public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public DateTime FoundationDate { get; set; }
    public string? EmployeeCount { get; set; }
    public bool Website { get; set; }

    public static int CompanyIdSeed { get; set; }

    public Company() {}

    public Company(string name, string password, string employeeCount, bool website) 
    {
        Id = CompanyIdSeed++;
        Name = name;
        Password = password;
        FoundationDate = DateTime.Now;
        EmployeeCount = employeeCount;
        Website = website;
    }
}
