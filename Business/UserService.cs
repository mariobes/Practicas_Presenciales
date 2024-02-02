using Practices.Data;
using Practices.Models;

namespace Practices.Business;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public void RegisterUser(string name, string email, string password, string dni, string phone)
    {
        try 
        {
            User user = new(name, email, password, dni, phone);
            _repository.AddUser(user);
            _repository.SaveChanges();
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar el usuario", e);
        }
    }

    public void PrintAllUsers()
    {
        try
        {
            Console.WriteLine("Lista de usuarios:\n");
            foreach (var user in _repository.GetAllUsers().Values)
            {
                Console.WriteLine($"ID: {user.Id}, Nombre: {user.Name}, Email: {user.Email}, Teléfono: {user.Phone}, DNI: {user.DNI}\n");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener los usuarios", e);
        }
    }

    public bool CheckUserExist(string email)
    {
        try
        {
            foreach (var user in _repository.GetAllUsers().Values)
            {
                if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar el usuario", e);
        }
    }

    public bool CheckLoginUser(string email, string pasword)
    {
        try
        {
            foreach (var user in _repository.GetAllUsers().Values)
            {
                if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    user.Password.Equals(pasword))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar el usuario", e);
        }
    }

    public User GetUser(string email)
    {
        try
        {
            return _repository.GetUser(email);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener el usuario", e);
        }
    }

    public void DeleteUser(string userEmail)
    {
        try
        {
            User userToDelete = _repository.GetUser(userEmail);
            _repository.RemoveUser(userToDelete);
            _repository.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al borrar el usuario", e);
        }
    }

    public void UpdateUser(string userEmail, string newName, string newEmail, string newPassword, string newDNI, string newPhone)
    {
        try 
        {
            User userToUpdate = _repository.GetUser(userEmail);
            _repository.UpdateUser(userToUpdate);
            _repository.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al actualizar el usuario", e);
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