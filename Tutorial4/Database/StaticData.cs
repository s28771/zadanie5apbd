using Tutorial4.Models;

namespace Tutorial4.Database;

public class StaticData
{
    public static List<Animal> animals = new List<Animal>()
    {
        new Animal(),
        new Animal(),
        new Animal(),
    };
    public static List<Visit> visits = new List<Visit>()
    {
        new Visit(),
        new Visit(),
        new Visit(),
    };
}