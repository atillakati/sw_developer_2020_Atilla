using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteKlassen
{
    public abstract class DataRepository
    {                     
        public abstract string Name { get; }
        
        public abstract int MaxSize { get; }
        

        public abstract void Write(string data);

        public abstract string Read();               
    }
}
