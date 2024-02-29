using WebStoreProject.Models;

namespace WebStoreProject.Services.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employees> GetAll();

        Employees? GetById(int id);

        int Add(Employees employee);
        bool Edit(Employees employee);
        bool Delete(int id);
    }
}
