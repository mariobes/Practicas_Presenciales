using Practices.Data;
using Practices.Models;

namespace Practices.Business;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;

    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public void RegisterCompany(string name, string password, string employeeCount, bool website)
    {
        try 
        {
            Company company = new(name, password, employeeCount, website);
            _repository.AddCompany(company);
            _repository.SaveChanges();
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar la compañía", e);
        }
    }

    public void PrintAllCompanies()
    {
        try
        {
            Console.WriteLine("Lista de compañías:\n");
            foreach (var company in _repository.GetAllCompanies().Values)
            {
                Console.WriteLine($"ID: {company.Id}, Nombre: {company.Name}, Fecha de fundación: {company.FoundationDate}, Número de empleados: {company.EmployeeCount}, Página web: {company.Website}\n");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener las compañías", e);
        }
    }

    public bool CheckCompanyExist(string name)
    {
        try
        {
                foreach (var company in _repository.GetAllCompanies().Values)
            {
                if (company.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar la compañía", e);
        }
    }

    public bool CheckLoginCompany(string name, string pasword)
    {
        try
        {
            foreach (var company in _repository.GetAllCompanies().Values)
            {
                if (company.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                    company.Password.Equals(pasword))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar la compañía", e);
        }
    }

    public Company GetCompany(string companyName)
    {
        try
        {
            return _repository.GetCompany(companyName);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener la compañía", e);
        }
    }

    public void DeleteCompany(string companyName)
    {
        try
        {
            Company companyToDelete = _repository.GetCompany(companyName);
            _repository.RemoveCompany(companyToDelete);
            _repository.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al borrar la compañía", e);
        }
    }

    public void UpdateCompany(string companyName, string newName, string newPassword, string newEmployeeCount, bool newWebsite)
    {
        try 
        {
            Company companyToUpdate = _repository.GetCompany(companyName);
            _repository.UpdateCompany(companyToUpdate);
            _repository.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al actualizar la compañía", e);
        }
    }

    public void SearchCompany()
    {
        try
        {
            string companyName = InputEmpty();
            Company company = GetCompany(companyName);

            if (company == null)
            {
                Console.WriteLine("No se ha encontrado ninguna compañía por ese nombre\n");
            }
            else
            {
                Console.WriteLine($"Nombre: {company.Name}, Fecha de fundación: {company.FoundationDate}, Número de empleados: {company.EmployeeCount}\n");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al buscar la compañía", e);
        }
    }
    public string InputEmpty()
    {
        try
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("El campo está vacío.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar el campo", e);
        }
    }

}