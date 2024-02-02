using Practices.Models;

namespace Practices.Data;

public interface ICompanyRepository
{
    void AddCompany(Company company);
    Company GetCompany(string name);
    Dictionary<string, Company> GetAllCompanies();
    void RemoveCompany(Company company);
    void UpdateCompany(Company company);
    void SaveChanges();
}
