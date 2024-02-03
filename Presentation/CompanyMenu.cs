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
        Console.WriteLine("1. Nuevo vuelo");
        Console.WriteLine("2. Borrar vuelo");
        Console.WriteLine("3. Ver todos los vuelos");
        Console.WriteLine("4. Cerrar sesión");
        SelectCompanyMenuOption(Console.ReadLine());
    }

    public void SelectCompanyMenuOption(string option)
    {
        MainMenu mainMenu = new(_userService, _companyService);

        switch (option)
        {
        case "1":
            RegisterFlight();
        break;
        case "2":
            DeleteFlight();
        break;
        case "3":
            GetAllFlights();
        break;
        case "4":
            Console.WriteLine("Has cerrado sesión"); 
            mainMenu.RegistrationMenu();
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            mainMenu.RegistrationMenu();
        break;
        }
    }

    private void RegisterFlight()
    {
        Console.WriteLine("Introduce el origen: ");
        string origin = _companyService.InputEmpty();

        Console.WriteLine("Introduce el destino: ");
        string destination = _companyService.InputEmpty();

        Console.WriteLine("Introduce la fecha de salida: ");
        DateTime departureDate = CheckDate();

        Console.WriteLine("Introduce la fecha de llegada: ");
        DateTime returnDate = CheckDate();

        Console.WriteLine("Introduce el precio: ");
        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Introduce un valor numérico válido: ");
        }

        _companyService.RegisterFlight(currentCompany, origin, destination, departureDate, returnDate, amount);
        MainCompanyMenu(currentCompany.Name);
    }

    private void DeleteFlight()
    {
        
    }

    private void GetAllFlights()
    {
        
    }

    private DateTime CheckDate()
    {
        string input;
        DateTime date;
        bool validDate = false;
        do
        {
            input = Console.ReadLine();
            if (DateTime.TryParse(input, out date))
            {
                validDate = true;
            } 
            else 
            {
                Console.WriteLine("La fecha introducida es incorrecta.");
            }

        } while (!validDate);

        return date;
    }

}