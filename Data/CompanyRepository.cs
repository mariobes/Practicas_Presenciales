using System.Text.Json;
using Practices.Models;

namespace Practices.Data;

public class CompanyRepository : ICompanyRepository
{
    private Dictionary<string, Company> _companies = new Dictionary<string, Company>();
    private readonly string _filePath = "companies.json";

    public CompanyRepository()
    {
        if (File.Exists(_filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(_filePath);
                var companies = JsonSerializer.Deserialize<IEnumerable<Company>>(jsonString);
                _companies = companies.ToDictionary(acc => acc.Id.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error al leer el archivo de compañías", e);
            }
        }

        if (_companies.Count == 0)
        {
            Company.CompanyIdSeed = 1;
        }
        else
        {
            Company.CompanyIdSeed = _companies.Count + 1;
        }
    }

    public void AddCompany(Company company)
    {
        _companies[company.Id.ToString()] = company;
    }

    public Company GetCompany(string companyName)
    {
        var allCompanies = GetAllCompanies();
        foreach (var company in allCompanies.Values)
        {
            if (company.Name.Equals(companyName, StringComparison.OrdinalIgnoreCase))
            {
                return company;
            }
        }

        return null;
    }

    public Dictionary<string, Company> GetAllCompanies()
    {
        return new Dictionary<string, Company>(_companies);
    }

    public void RemoveCompany(Company company)
    {
        _companies.Remove(company.Id.ToString());
    }

    public void UpdateCompany(Company company)
    {
        _companies[company.Id.ToString()] = company;
    }

    public void SaveChanges()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_companies.Values, options);
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al guardar cambios en el archivo de compañías", e);
        }
    }

}