namespace Practices.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public string? DNI { get; set; }
    public List<Booking> MyBookings { get; set; }

    public static int UserIdSeed { get; set; }

    public User() {}

    public User(string name, string email, string password, string phone, string dni) 
    {
        Id = UserIdSeed++;
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        DNI = dni;
        MyBookings = new List<Booking>();
    }
}
