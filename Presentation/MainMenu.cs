using Practices.Business;
using Practices.Models;

namespace Practices.Presentation;
public class MainMenu
{
    public readonly IUserService _userService;
    public readonly ICompanyService _companyService;

    public MainMenu(IUserService userService, ICompanyService companyService)
    {
        _userService = userService;
        _companyService = companyService;
    }

    public void RegistrationMenu()
    {
    Console.WriteLine("\n~~~~~~~~~~~~ BIENVENIDO ~~~~~~~~~~~~\n");
    Console.WriteLine("1. Nuevo registro");
    Console.WriteLine("2. Iniciar sesión");
    Console.WriteLine("3. Salir");
    SelectRegistrationOption(Console.ReadLine());
    }
    public void SelectRegistrationOption(string option)
    {
        switch (option)
        {
        case "1":
            SignUp();
        break;
        case "2":
            SignIn();
        break;
        case "3":
            Console.Write("¡Hasta pronto!");
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            RegistrationMenu();
        break;
        }
    }

    private void SignUp()
    {
        Console.Write("1. Usuario | 2. Compañía");
        string option = _userService.InputEmpty();

        switch (option)
        {
        case "1":
            Console.Write("Nombre: ");
            string name = _userService.InputEmpty();
        
            Console.Write("Dirección de correo: ");
            string email = _userService.InputEmpty();

            Console.Write("Contraseña: ");
            string password = _userService.InputEmpty();

            Console.Write("Número de teléfono: ");
            string phone = _userService.InputEmpty();

            Console.Write("DNI: ");
            string dni = _userService.InputEmpty();

            if (_userService.CheckUserExist(email))
            {
                Console.WriteLine("Error, ya existe una cuenta asociada al teléfono, correo o DNI introducido.");
                RegistrationMenu();
            }
            else
            {
                if (email.Contains("@"))
                {
                    _userService.RegisterUser(name, email, password, phone, dni);
                    UserMenu userMenu = new(_userService, _companyService);
                    userMenu.MainUserMenu(email);
                    Console.WriteLine("Usuario registrado con éxito!");
                }
                else
                {
                    Console.WriteLine("Error, el correo debe de contener @.");
                    RegistrationMenu();
                }
            }
        break;
        case "2":
            Console.Write("Nombre: ");
            name = _userService.InputEmpty();
        
            Console.Write("Contraseña: ");
            password = _userService.InputEmpty();

            Console.Write("Número de empleados: ");
            string employeeCount = _userService.InputEmpty();

            Console.Write("Tiene sitio web (Si: Y | No: N)");
            bool website = false;
            string websiteInput;
            do
            {
                websiteInput = _userService.InputEmpty().ToLower();
                if (websiteInput == "y")
                {
                    website = true;
                }
                else if (websiteInput == "n")
                {
                    website = false;
                }
                else
                {
                    Console.Write("Error, introduce una opción válida (Si: Y | No: N): ");
                }
            } while (websiteInput != "y" && websiteInput != "n");

            if (_companyService.CheckCompanyExist(name))
            {
                Console.WriteLine("Error, ya existe una compañía con ese nombre");
                RegistrationMenu();
            }
            else
            {
                _companyService.RegisterCompany(name, password, employeeCount, website);
                CompanyMenu companyMenu = new(_userService, _companyService);
                companyMenu.MainCompanyMenu(name);
                Console.WriteLine("¡Compañía registrada con éxito!");
            }
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            RegistrationMenu();
        break;
        }

    }

    private void SignIn()
    {
        Console.Write("1. Usuario | 2. Compañía");
        string option = _userService.InputEmpty();

        switch (option)
        {
        case "1":
            Console.Write("Dirección de email: ");
            string email = _userService.InputEmpty();
            Console.Write("Contraseña: ");
            string password = _userService.InputEmpty();
            if (_userService.CheckLoginUser(email, password))
            {
                UserMenu userMenu = new(_userService, _companyService);
                userMenu.MainUserMenu(email);
            } 
            else
            {
                Console.WriteLine("El correo o la contraseña introducida es incorrecta.");
                RegistrationMenu();
            }
        break;
        case "2":
            Console.Write("Nombre de la compañía: ");
            string name = _companyService.InputEmpty();
            Console.Write("Contraseña: ");
            password = _companyService.InputEmpty();
            if (_companyService.CheckLoginCompany(name, password))
            {
                CompanyMenu companyMenu = new(_userService, _companyService);
                companyMenu.MainCompanyMenu(name);            } 
            else
            {
                Console.WriteLine("El correo o la contraseña introducida es incorrecta.");
                RegistrationMenu();
            }    
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            RegistrationMenu();
        break;
        }
    }

}
