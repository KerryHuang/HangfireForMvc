using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeesService : Service<Employees>, IEmployeesService
    {
        public EmployeesService(IRepository<Employees> repository) : base(repository)
        {
        }
    }
}
