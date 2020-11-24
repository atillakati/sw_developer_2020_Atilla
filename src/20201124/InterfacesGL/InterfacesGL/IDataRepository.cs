using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteKlassen
{
    public interface IDataRepository
    {
        string Name { get; }

        int MaxSize { get; }


        void Write(string data);

        string Read();
    }
}
