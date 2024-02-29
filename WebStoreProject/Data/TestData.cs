using WebStoreProject.Models;

namespace WebStoreProject.Data
{
    public class TestData
    {
        public static List<Employees> Employees { get; } = new()
        {
            new Employees{Id = 1, FirstName = "Maksim", LastName = "Something", Patronymic = "Noogvre", Age = 40, Birthday = new DateTime(2345, 10, 15), Experience = 23},
            new Employees{Id = 2, FirstName = "Peter", LastName = "GoodScon", Patronymic = "Someone", Age = 40,  Birthday = new DateTime(2345, 10, 15), Experience = 23},
            new Employees{Id = 3, FirstName = "Scott", LastName = "Johnson", Patronymic = "Antoher", Age = 40,  Birthday = new DateTime(2345, 10, 15), Experience = 23},
        };
    }
}
