using com.terriblecode.dal;

namespace com.terriblecode.businesslayer
{
    public class EmployeeService
    {
        public static readonly EmployeeService Instance = new EmployeeService();

        private EmployeeService()
        {}

        public Employee GetById(int id)
        {
            var repository = new Repository<Employee>();

            return repository.GetById(id);
        }

        public void Update(Employee employee)
        {
            var repository = new Repository<Employee>();
            
            repository.Update(employee);
        }
    }
}