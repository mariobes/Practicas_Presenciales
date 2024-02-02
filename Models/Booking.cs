namespace Practices.Models;
public class Booking
{
    public int Id { get; set; }
    public Company Company { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int PassengerCount { get; set; }
    public double Amount { get; set; }

    public static int BookingIdSeed { get; set; }

    public Booking() {}

    public Booking(Company company, string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount, double amount) 
    {
        Id = BookingIdSeed++;
        Company = company;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        ReturnDate = returnDate;
        PassengerCount = passengerCount;
        Amount = amount;
    }
}
