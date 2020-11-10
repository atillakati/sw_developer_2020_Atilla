using System;

namespace GrundlagenKlassen
{
    public class Employee
    {
        public string Name;
        public Guid Id;
        public decimal Salary;
        public DateTime Birthday;
        public EmployeeState State;

        //std. Konstruktor
        //public Employee()
        //{
        //    Name = "No Name";            
        //    Salary = 1000.0m;
        //    Birthday = new DateTime(1998, 11, 1);

        //    Id = Guid.NewGuid();
        //    State = EmployeeState.Employed;
        //}

        //user specific constructor
        public Employee(string name, DateTime birthday, decimal salary)
        {
            Id = Guid.NewGuid();
            State = EmployeeState.Employed;

            Name = name;
            Birthday = birthday;
            Salary = salary;
        }


        public void DisplayInfos()
        {
            Console.WriteLine($"MA Id:    {Id}");
            Console.WriteLine($"Name:     {Name} [EUR {Salary}]");
            Console.WriteLine($"Birthday: {Birthday.ToLongDateString()}");
            Console.WriteLine($"State:    {State}");
            Console.WriteLine();
        }

        public void UpdateSalary(double amountInPercent)
        {
            if (State != EmployeeState.Discontinued)
            {
                //Berechnung neues Gehalt
                Salary = Salary + Salary * (decimal)(amountInPercent / 100);
                Console.WriteLine($"Gehalt von {Name} wurde aktualisiert.");
            }
        }

    }
}