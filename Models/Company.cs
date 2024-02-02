namespace Practices.Models;
public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public int EmployeeCount { get; set; }
    public bool Website { get; set; }

    public static int CompanyIdSeed { get; set; }

    public Company() {}

    public Company(string name, int employeeCount, bool website) 
    {
        Id = CompanyIdSeed++;
        Name = name;
        FoundationDate = DateTime.Now;
        EmployeeCount = employeeCount;
        Website = website;
    }
}
