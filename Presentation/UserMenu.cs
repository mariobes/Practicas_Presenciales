using Practices.Business;
using Practices.Models;

namespace Practices.Presentation;

public class UserMenu
{
    public readonly IUserService _userService;
    public readonly ICompanyService _companyService;
    private User currentUser;

    public UserMenu(IUserService userService, ICompanyService companyService)
    {
        _userService = userService;
        _companyService = companyService;
    }

    public void MainUserMenu(string userEmail)
    {
        currentUser = _userService.GetUser(userEmail);

        Console.WriteLine($"¡Hola, {currentUser.Name}!\n");
        Console.WriteLine("1. Modificar mi cuenta");
        Console.WriteLine("2. Lista de compañías");
        Console.WriteLine("3. Buscar una compañías");
        Console.WriteLine("4. Reservar vuelo");
        Console.WriteLine("5. Ver mis reservas");
        Console.WriteLine("6. Borrar mi cuenta");
        Console.WriteLine("7. Cerrar sesión");
        SelectUserMenuOption(Console.ReadLine());
    }

    public void SelectUserMenuOption(string option)
    {        
        MainMenu mainMenu = new(_userService, _companyService);

        switch (option)
        {
        case "1":
            
        break;
        case "2":
            _companyService.PrintAllCompanies();
            MainUserMenu(currentUser.Email);
        break;
        case "3":          
            Console.WriteLine("Introduce el nombre de la compañía"); 
            _companyService.SearchCompany();
            MainUserMenu(currentUser.Email);
        break;
        case "4":            
            
        break;
        case "5":            
            
        break;
        case "6":  
            Console.WriteLine("Has eliminado tu cuenta");
            _userService.DeleteUser(currentUser.Email);    
            mainMenu.RegistrationMenu();
        break;
        case "7":            
            
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            SelectUserMenuOption(Console.ReadLine());
        break;
        }
    }





    

}