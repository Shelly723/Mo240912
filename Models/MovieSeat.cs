using Microsoft.AspNetCore.Mvc;
using Mo240912.Models;

namespace Mo240912.Models;
public class MovieSeat
{
    public List<Movies> Movies { get; set; }
    public List<Showtimes> Showtimes { get; set; }
}
