using Practices.Business;
using Practices.Models;

namespace Practices.Presentation;

public class CompanyMenu
{
    public readonly IUserService _userService;
    public readonly ICompanyService _companyService;
    private Company currentCompany;

    public CompanyMenu(IUserService userService, ICompanyService companyService)
    {
        _userService = userService;
        _companyService = companyService;
    }

    public void MainCompanyMenu(string companyName)
    {
        currentCompany = _companyService.GetCompany(companyName);

        Console.WriteLine($"¡Hola, {currentCompany.Name}!\n");
        Console.WriteLine("1. Mi cuenta");
        Console.WriteLine("2. Lista de criptomonedas");
        Console.WriteLine("3. Cerrar sesión");
        SelectCompanyMenuOption(Console.ReadLine());
    }

    public void SelectCompanyMenuOption(string option)
    {

    }







}