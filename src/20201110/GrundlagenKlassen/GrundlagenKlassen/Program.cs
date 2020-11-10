using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenKlassen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanziierung
            Employee ma = new Employee("Max Musterman", new DateTime(1985, 5, 20), 1580.0m);
                                    
            ma.DisplayInfos();

            ma.State = EmployeeState.Discontinued;
            ma.Salary = 10000m;

            ma.UpdateSalary(10.0);

            ma.DisplayInfos();
        }
    }
}
