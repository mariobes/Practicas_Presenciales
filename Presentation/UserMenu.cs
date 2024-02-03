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
            UpdateUser(currentUser.Email);
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
            Console.WriteLine("Has cerrado sesión");        
            mainMenu.RegistrationMenu();
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            SelectUserMenuOption(Console.ReadLine());
        break;
        }
    }

    private void UpdateUser(string email)
    {
        Console.Write("Nombre: ");
        string newName = _userService.InputEmpty();
    
        Console.Write("Dirección de correo: ");
        string newEmail = _userService.InputEmpty();

        Console.Write("Contraseña: ");
        string newPassword = _userService.InputEmpty();

        Console.Write("Número de teléfono: ");
        string newPhone = _userService.InputEmpty();

        Console.Write("DNI: ");
        string newDni = _userService.InputEmpty();

        if (_userService.CheckUserExist(newEmail))
        {
            Console.WriteLine("Error, ya existe una cuenta asociada al correo introducido.");
        }
        else
        {
            if (newEmail.Contains("@"))
            {
                _userService.UpdateUser(email, newName, newEmail, newPassword, newPhone, newDni);
                Console.WriteLine("Usuario actualizado con éxito!");
            }
            else
            {
                Console.WriteLine("Error, el correo debe de contener @.");
            }
        }

        MainUserMenu(currentUser.Email);

    }





    

}