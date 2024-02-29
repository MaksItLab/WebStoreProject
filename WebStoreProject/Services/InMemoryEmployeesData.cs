using WebStoreProject.Data;
using WebStoreProject.Models;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly ICollection<Employees> __Employees;
        private int _MaxFreeId;

        public InMemoryEmployeesData()
        {
            __Employees = TestData.Employees;
            _MaxFreeId = __Employees.DefaultIfEmpty().Max(e => e?.Id ?? 0) + 1;
        }

        public int Add(Employees employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (__Employees.Contains(employee)) return employee.Id;

            employee.Id = _MaxFreeId++;
            __Employees.Add(employee);
            return employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                return false;
            }
            __Employees.Remove(employee);
            return true;
        }

        public bool Edit(Employees employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (__Employees.Contains(employee)) return true;

            var db_employee = GetById(employee.Id);

            if(db_employee is null) return false;

            db_employee.FirstName = employee.FirstName;
            db_employee.LastName = employee.LastName;
            db_employee.Age = employee.Age;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Birthday = employee.Birthday;
            db_employee.Experience = employee.Experience;

            return true;
        }

        public IEnumerable<Employees> GetAll() => __Employees;

        public Employees? GetById(int id)
        {
            return __Employees.FirstOrDefault(empl => empl.Id == id);
        }
    }
}
