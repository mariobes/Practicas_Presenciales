using Practices.Models;

namespace Practices.Business;

public interface ICompanyService
{
    void RegisterCompany(string name, string password, string employeeCount, bool website);
    void PrintAllCompanies();
    bool CheckCompanyExist(string name);
    bool CheckLoginCompany(string name, string password);
    Company GetCompany(string name);
    void DeleteCompany(string name);
    void UpdateCompany(string name, string newName, string newPassword, string newEmployeeCount, bool newWebsite);
    void SearchCompany();
    void RegisterFlight(Company company, string origin, string destination, DateTime departureDate, DateTime returnDate, double amount);
    string InputEmpty();
}