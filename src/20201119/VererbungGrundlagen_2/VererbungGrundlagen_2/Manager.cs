using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungGrundlagen_2
{
    public class Manager : Employee
    {
        private int _shares;        

        public Manager(string vorname, string nachname, DateTime geburtsDatum, int shares, decimal gehalt)
            : base(vorname, nachname, geburtsDatum, gehalt)
        {
            _shares = shares;
        }

        public int Shares
        {
            get { return _shares; }
        }

        public bool AddShares(int amount)
        {
            if(_shares + amount > 90 || amount < 0)
            {
                return false;
            }

            _shares += amount;
            return true;
        }

        public bool RemoveShares(int amount)
        {
            if (_shares - amount < 0 || amount < 0)
            {
                return false;
            }

            _shares -= amount;
            return true;
        }
    }
}
