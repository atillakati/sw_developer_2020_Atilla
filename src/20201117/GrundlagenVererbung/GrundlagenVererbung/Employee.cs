using System;

namespace GrundlagenVererbung
{
    public class Employee
    {
        private string _vorname;
        private string _nachname;
        private Guid _id;
        private DateTime _geburtsDatum;
        private decimal _gehalt;
                

        public Employee(string vorname, string nachname, DateTime geburtsDatum, decimal gehalt)
        {
            _vorname = vorname;
            _nachname = nachname;
            _geburtsDatum = geburtsDatum;
            _gehalt = gehalt;
            _id = Guid.NewGuid();            
        }


        public decimal Gehalt
        {
            get { return _gehalt; }        
        }

        public DateTime GeburtsDatum
        {
            get { return _geburtsDatum; }        
        }

        public Guid Id
        {
            get { return _id; }        
        }

        public string Name
        {
            get { return $"{_vorname} {_nachname}"; }
            set { _nachname = value; }
        }


        public decimal GetCalculatedSalary()
        {
            return _gehalt;
        }

        public string GetInfoString()
        {
            return $"[{_id}]: {_vorname} {_nachname} - {_geburtsDatum.Date}";
        }

    }
}