using Practices.Business;

namespace Practices.Presentation;
public class MainMenu
{
    public readonly IUserService _userService;

    public MainMenu(IUserService userService)
    {
        _userService = userService;
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

            if (email.Contains("@"))
            {
                _userService.RegisterUser(name, email, password, phone, dni);
                Console.WriteLine("¡Registro completado!");
            }
            else
            {
                Console.WriteLine("Error, el correo debe de contener @.");
                RegistrationMenu();
            }
        break;
        case "2":
            
        break;
        default:
            Console.WriteLine("Introduce una opción válida");
            RegistrationMenu();
        break;
        }

    }

    private void SignIn()
    {

    }


}
