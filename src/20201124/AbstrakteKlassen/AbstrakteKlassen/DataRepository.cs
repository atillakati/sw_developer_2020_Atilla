using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteKlassen
{
    public abstract class DataRepository
    {
        private int _maxSize;
        private string _name;

        public DataRepository(string name, int maxSize)
        {
            _name = name;
            _maxSize = maxSize;
        }

        public string Name
        {
            get { return _name; }
        }

        public int MaxSize
        {
            get { return _maxSize; }
        }

        public abstract void Write(string data);

        public abstract string Read();

        public override string ToString()
        {
            return $"RepositoryType: {_name} | Size limit: {_maxSize}";
        }

    }
}
