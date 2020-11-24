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
        private readonly string _name;
        private readonly int _maxSize;
        private string _myMemory;

        public MemoryRepository(int maxSize)            
        {
            _myMemory = string.Empty;
            _name = "RAM Repository";
            _maxSize = maxSize;
        }

        public override string Name
        {
            get { return _name; }
        }

        public override int MaxSize
        {
            get { return _maxSize; }
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
