using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteKlassen
{
    public class MemoryRepository : DataRepository
    {
        private string _myMemory;

        public MemoryRepository(int maxSize)
            :base("RAM Repository", maxSize)
        {
            _myMemory = string.Empty;
        }

        public override string Read()
        {
            return _myMemory;
        }

        public override void Write(string data)
        {
            int countOfCharsToWrite = data.Length;

            if(countOfCharsToWrite > MaxSize)
            {
                Debug.WriteLine($"Achtung! Daten grösser als MaxSize: {data.Length} Zeichen");
                countOfCharsToWrite = MaxSize;
            }

            _myMemory = data.Substring(0, countOfCharsToWrite);
        }
    }
}
